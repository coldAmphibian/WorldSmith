using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sce.Atf;
using Sce.Atf.Adaptation;
using Sce.Atf.Applications;
using Sce.Atf.Dom;

namespace WorldsmithATF.UI
{
    class ProjectTreeView : DomNodeAdapter, ITreeView, IItemView, IObservableContext
    {

        protected override void OnNodeSet()
        {
            DomNode.AttributeChanged += new EventHandler<AttributeEventArgs>(root_AttributeChanged);
            DomNode.ChildInserted += new EventHandler<ChildEventArgs>(root_ChildInserted);
            DomNode.ChildRemoved += new EventHandler<ChildEventArgs>(root_ChildRemoved);
            Reloaded.Raise(this, EventArgs.Empty);

            base.OnNodeSet();
        }

       
        

        #region IObservableContext Members

        public event EventHandler<ItemChangedEventArgs<object>> ItemChanged;

        public event EventHandler<ItemInsertedEventArgs<object>> ItemInserted;

        public event EventHandler<ItemRemovedEventArgs<object>> ItemRemoved;

        public event EventHandler Reloaded;

        #endregion

        public void GetInfo(object item, ItemInfo info)
        {
            info.Label = "[" + item.GetType().Name + "]";
        }

        public IEnumerable<object> GetChildren(object parent)
        {
            DomNode node = parent as DomNode;
            return node.Children;
        }

        #region ITreeView Members
        public object Root
        {
            get { return DomNode; }
        }
        #endregion

        private void root_AttributeChanged(object sender, AttributeEventArgs e)
        {
            Event.Raise<ItemChangedEventArgs<object>>(ItemChanged, this, new ItemChangedEventArgs<object>(e.DomNode));
                     
        }

        private void root_ChildInserted(object sender, ChildEventArgs e)
        {
            Event.Raise<ItemInsertedEventArgs<object>>(
                ItemInserted, this, new ItemInsertedEventArgs<object>(-1, e.Child, e.Parent));
        }

        private void root_ChildRemoved(object sender, ChildEventArgs e)
        {
            Event.Raise<ItemRemovedEventArgs<object>>(
                ItemRemoved, this, new ItemRemovedEventArgs<object>(-1, e.Child, e.Parent));
        }

    }
}
