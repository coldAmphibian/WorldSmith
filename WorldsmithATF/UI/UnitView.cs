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
    class UnitView : ITreeView, IItemView, ISelectionContext, IInitializable
    {

        private Selection<object> selection;
        public DomNode RootNode
        {
            get;
            set;
        }

        public UnitView()
        {
         
            selection = new Selection<object>();
            selection.Changed += new EventHandler(selection_Changed);

            RootNode = new DomNode(DotaObjectsSchema.DefaultUnitContainerType.Type);

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
            get
            {
                return RootNode;
            }
        }
        #endregion

        #region IItemView Members
        public void GetInfo(object item, ItemInfo info)
        {
            DomNode node = item as DomNode;
            if (node != null)
            {
                if(node.Children.Count() > 0)
                {
                    info.IsLeaf = false;
                    info.Label = "Container";
                }
                else
                {
                    info.IsLeaf = true;
                    info.Label = "Wiggledywook";
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
