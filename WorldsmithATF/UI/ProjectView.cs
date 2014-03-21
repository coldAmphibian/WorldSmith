using Sce.Atf;
using Sce.Atf.Applications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.UI
{
    class ProjectView : ITreeView, IItemView, ISelectionContext
    {
        private string ProjectPath = "";
        private Selection<object> selection;

        public ProjectView(string Path)
        {
            ProjectPath = Path;

            selection = new Selection<object>();
            selection.Changed += new EventHandler(selection_Changed);

            // suppress compiler warning
            if (SelectionChanging == null) return;
        }

        private static DirectoryInfo[] GetSubDirectories(DirectoryInfo directoryInfo)
        {
            DirectoryInfo[] directories = null;
            try
            {
                directories = directoryInfo.GetDirectories();
            }
            catch
            {
            }

            return directories;
        }


        #region ITreeView Members
        public IEnumerable<object> GetChildren(object parent)
        {          
            IEnumerable<object> result = null;
            DirectoryInfo directoryInfo = parent as DirectoryInfo;
            if (directoryInfo != null)
                result = GetSubDirectories(directoryInfo); //may return null

            if (result == null)
                return EmptyEnumerable<object>.Instance;
            return result;
        }

        public object Root
        {
            get {               
                return new DirectoryInfo(ProjectPath); 
            }
        }
        #endregion

        #region IItemView Members
        public void GetInfo(object item, ItemInfo info)
        {
            DirectoryInfo directoryInfo = item as DirectoryInfo;
            if (directoryInfo != null)
            {
                info.Label = directoryInfo.Name;
                info.ImageIndex = info.GetImageList().Images.IndexOfKey(Resources.ComputerImage);
                DirectoryInfo[] directories = GetSubDirectories(directoryInfo);

                info.IsLeaf =
                    directories != null &&
                    directories.Length == 0;
            }
        }
        #endregion

        #region ISelectionContext Members
        public T GetLastSelected<T>()
                   where T : class
        {
            return selection.GetLastSelected<T>();
        }

        public IEnumerable<T> GetSelection<T>()
                   where T : class
        {
            return selection.AsIEnumerable<T>();
        }

        public object LastSelected
        {
            get { return selection.LastSelected; }
        }
        public IEnumerable<object> Selection
        {
            get { return selection; }
            set { selection.SetRange(value); }
        }

        public event EventHandler SelectionChanged;

        public event EventHandler SelectionChanging;

        private void selection_Changed(object sender, EventArgs e)
        {
            SelectionChanged.Raise(this, EventArgs.Empty);
        }

        public bool SelectionContains(object item)
        {
            return selection.Contains(item);
        }

        public int SelectionCount
        {
            get { return selection.Count; }
        }

        #endregion

    }
}
