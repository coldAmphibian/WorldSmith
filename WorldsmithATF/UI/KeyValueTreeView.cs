using KVLib;
using Sce.Atf;
using Sce.Atf.Adaptation;
using Sce.Atf.Applications;
using Sce.Atf.Controls;
using Sce.Atf.Controls.PropertyEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.UI
{
    class KeyValueTreeView : ITreeListView, IItemView, IObservableContext, ISelectionContext, IValidationContext
    {
        private static int s_dataImageIndex = -1;
        private static int s_folderImageIndex = -1;

        private static readonly string[] s_columnNames =
            new[]
            {
                "Name",                
                "Value",
            };

        private readonly List<KeyValue> m_data = new List<KeyValue>();

        private readonly Selection<object> m_selection = new Selection<object>();

          /// <summary>
        /// Constructor</summary>
        public KeyValueTreeView()
        {
            m_selection.Changing += TheSelectionChanging;
            m_selection.Changed += TheSelectionChanged;

            if (s_dataImageIndex == -1)
            {
                s_dataImageIndex =
                    ResourceUtil.GetImageList16().Images.IndexOfKey(
                        Resources.DataImage);
            }

            if (s_folderImageIndex == -1)
            {
                s_folderImageIndex =
                    ResourceUtil.GetImageList16().Images.IndexOfKey(
                        Resources.FolderImage);
            }

            // Stop compiler warning
            if (Cancelled == null) return;
        }

        public void AddRoot(KeyValue kv)
        {
            m_data.Add(kv);
        }

        /// <summary>
        /// Gets data item at index</summary>
        /// <param name="index">Index of data item</param>
        /// <returns>Data item at index</returns>
        public KeyValue this[int index]
        {
            get { return m_data[index]; }
        }

        /// <summary>
        /// Clears all data items</summary>
        public void Clear()
        {
            m_data.Clear();
            Reloaded.Raise(this, EventArgs.Empty);
        }
      

        #region ITreeListView Interface

        /// <summary>
        /// Gets the root level objects of the tree view</summary>
        public IEnumerable<object> Roots
        {
            get { return m_data.AsIEnumerable<object>(); }
        }

        /// <summary>
        /// Gets enumeration of the children of the given parent object</summary>
        /// <param name="parent">Parent object</param>
        /// <returns>Enumeration of the children of the parent object</returns>
        public IEnumerable<object> GetChildren(object parent)
        {
            var dataParent = parent.As<KeyValue>();
            if (dataParent == null)
                yield break;

            if (!dataParent.HasChildren)
                yield break;

            foreach (var data in dataParent.Children)
                yield return data;
        }

        /// <summary>
        /// Gets names for columns</summary>
        public string[] ColumnNames
        {
            get { return s_columnNames; }
        }

        #endregion

        #region IItemView Interface

        /// <summary>
        /// Fills in or modifies the given display info for the item</summary>
        /// <param name="obj">Item</param>
        /// <param name="info">Display info to update</param>
        public void GetInfo(object obj, ItemInfo info)
        {
            var data = obj.As<KeyValue>();
            if (data == null)
                return;

            info.Label = data.Key;
            info.Properties =
                new object[]
                {
                    data.GetString()
                };

            info.IsLeaf = !data.HasChildren;
            info.ImageIndex =
                data.HasChildren
                    ? s_folderImageIndex
                    : s_dataImageIndex;
        }

        #endregion

        #region IObservableContext Interface

        /// <summary>
        /// Event that is raised when an item is inserted</summary>
        public event EventHandler<ItemInsertedEventArgs<object>> ItemInserted;

        /// <summary>
        /// Event that is raised when an item is removed</summary>
        public event EventHandler<ItemRemovedEventArgs<object>> ItemRemoved;

        /// <summary>
        /// Event that is raised when an item is changed</summary>
        public event EventHandler<ItemChangedEventArgs<object>> ItemChanged;

        /// <summary>
        /// Event that is raised when the collection has been reloaded</summary>
        public event EventHandler Reloaded;

        #endregion

        #region ISelectionContext Interface

        /// <summary>
        /// Gets or sets the enumeration of selected items</summary>
        public IEnumerable<object> Selection
        {
            get { return m_selection; }
            set { m_selection.SetRange(value); }
        }

        /// <summary>
        /// Returns all selected items of the given type</summary>
        /// <typeparam name="T">Desired item type</typeparam>
        /// <returns>All selected items of the given type</returns>
        public IEnumerable<T> GetSelection<T>() where T : class
        {
            return m_selection.AsIEnumerable<T>();
        }

        /// <summary>
        /// Gets the last selected item</summary>
        public object LastSelected
        {
            get { return m_selection.LastSelected; }
        }

        /// <summary>
        /// Gets the last selected item of the given type; this may not be the same
        /// as the LastSelected item</summary>
        /// <typeparam name="T">Desired item type</typeparam>
        /// <returns>Last selected item of the given type</returns>
        public T GetLastSelected<T>() where T : class
        {
            return m_selection.GetLastSelected<T>();
        }

        /// <summary>
        /// Returns whether the selection contains the given item</summary>
        /// <param name="item">Item</param>
        /// <returns>True iff the selection contains the given item</returns>
        /// <remarks>Override to customize how items are compared for equality, e.g., for
        /// tree views, the selection might be adaptable paths, in which case the override
        /// could compare the item to the last elements of the selected paths.</remarks>
        public bool SelectionContains(object item)
        {
            return m_selection.Contains(item);
        }

        /// <summary>
        /// Gets the number of items in the current selection</summary>
        public int SelectionCount
        {
            get { return m_selection.Count; }
        }

        /// <summary>
        /// Event that is raised before the selection changes</summary>
        public event EventHandler SelectionChanging;

        /// <summary>
        /// Event that is raised after the selection changes</summary>
        public event EventHandler SelectionChanged;

        #endregion

        #region IValidationContext Interface

        /// <summary>
        /// Event that is raised before validation begins</summary>
        public event EventHandler Beginning;

        /// <summary>
        /// Event that is raised after validation is cancelled</summary>
        public event EventHandler Cancelled;

        /// <summary>
        /// Event that is raised before validation ends</summary>
        public event EventHandler Ending;

        /// <summary>
        /// Event that is raised after validation ends</summary>
        public event EventHandler Ended;

        #endregion
        private void Reload()
        {
            Beginning.Raise(this, EventArgs.Empty);
            Reloaded.Raise(this, EventArgs.Empty);
            Ending.Raise(this, EventArgs.Empty);
            Ended.Raise(this, EventArgs.Empty);
        }

        private void RemoveItem(KeyValue item)
        {
            if (item == null)
                return;

           // if (item.Parent != null)
           //     item.Parent.Children.Remove(item);
           // else
           //     m_data.Remove(item);

            ItemRemoved.Raise(this, new ItemRemovedEventArgs<object>(-1, item));
        }
     

        private void TheSelectionChanging(object sender, EventArgs e)
        {
            SelectionChanging.Raise(this, EventArgs.Empty);
        }

        private void TheSelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged.Raise(this, EventArgs.Empty);
        }

        private void DataItemChanged(object sender, EventArgs e)
        {
            var data = (KeyValue)sender;

            ItemChanged.Raise(this, new ItemChangedEventArgs<object>(data));
        }
    }
}
