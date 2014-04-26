using Sce.Atf;
using Sce.Atf.Applications;
using Sce.Atf.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldsmithATF.Project;
using Sce.Atf.Adaptation;

namespace WorldsmithATF.UI
{
    class ProjectView : ITreeView, IItemView, ISelectionContext, IInitializable
    {

        private Selection<object> selection;

       

        public ProjectView()
        {
            Root = new DomNode(DotaObjectsSchema.FolderType.Type).As<ProjectFolder>();

            selection = new Selection<object>();
            selection.Changed += new EventHandler(selection_Changed);

            // suppress compiler warning
            if (SelectionChanging == null) return;

            
        }

     


        #region ITreeView Members
        public IEnumerable<object> GetChildren(object parent)
        {
            DomNode node = parent.As<DomNode>();
            return node.Children;
        }

        public object Root
        {
            get;
            set;
        }
        #endregion

        #region IItemView Members
        public void GetInfo(object item, ItemInfo info)
        {
            DomNode node = item as DomNode;
            if(node != null)
            {                
                if(node.Type == DotaObjectsSchema.FolderType.Type)
                {
                    ProjectFolder folder = node.As<ProjectFolder>();
                    info.Label = folder.Name;
                    info.IsLeaf = false;
                    info.ImageIndex = info.GetImageList().Images.IndexOfKey(Resources.FolderIcon);
                }
                else
                {
                    //Lets figure out what it is
                    ProjectFile file = node.As<ProjectFile>();
                    info.Label = file.Name;
                    info.IsLeaf = true;

                    string ext = Path.GetExtension(file.Path);
                    if(ProjectLoader.FileTypes.ContainsKey(ext))
                    {
                        info.ImageIndex = info.GetImageList().Images.IndexOfKey(ProjectLoader.FileTypes[ext].DisplayImageKey);
                    }
                    else
                    {
                        info.ImageIndex = info.GetImageList().Images.IndexOfKey(Resources.DataImage);
                    }
                    
                }
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


        public void Initialize()
        {
            
        }
    }
}
