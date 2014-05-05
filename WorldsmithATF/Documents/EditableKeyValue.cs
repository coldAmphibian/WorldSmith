﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sce.Atf;
using Sce.Atf.Applications;
using System.ComponentModel;
using KVLib;
using Sce.Atf.Controls.PropertyEditing;
using System.Reflection;

namespace WorldsmithATF.Documents
{
    class EditableKeyValue : CustomTypeDescriptor
    {
        [PropertyEditing]
        public string Key
        {
            get { return KeyValues.Key; }
           
        }

        private List<KeyValue> kvList;
        [PropertyEditing]
        public List<KeyValue> Children
        {
            get { return kvList; }
            set { kvList = value; }
        }
        [PropertyEditing]
        public string Item
        {
            get { return KeyValues.GetString(); }
            set { KeyValues.Set(value); }
        }

        private KeyValue KeyValues
        {
            get;
            set;
        }

        /// <summary>
        /// Event that is raised after an item changed</summary>
        public event EventHandler ItemChanged;

        public EditableKeyValue(KeyValue kv)
        {
            KeyValues = kv;
            kvList = KeyValues.Children.ToList();
        }

        /// <summary>
        /// Returns a collection of property descriptors for the object represented by this type descriptor</summary>
        /// <returns>System.ComponentModel.PropertyDescriptorCollection containing the property descriptions for the object 
        /// represented by this type descriptor. The default is System.ComponentModel.PropertyDescriptorCollection.Empty.</returns>
        public override PropertyDescriptorCollection GetProperties()
        {
            var props = new PropertyDescriptorCollection(null);

            foreach (var property in GetType().GetProperties())
            {
                var propertyDesc =
                    new PropertyPropertyDescriptor(property, GetType());

                propertyDesc.ItemChanged += PropertyDescItemChanged;

                foreach (Attribute attr in propertyDesc.Attributes)
                {
                    if (attr.GetType().Equals(typeof(PropertyEditingAttribute)))
                        props.Add(propertyDesc);
                }
            }

            return props;
        }

        private void PropertyDescItemChanged(object sender, EventArgs e)
        {
            ItemChanged.Raise(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns an object that contains the property described by the specified property descriptor</summary>
        /// <param name="pd">Property descriptor for which to retrieve the owning object</param>
        /// <returns>System.Object that owns the given property specified by the type descriptor. The default is null.</returns>
        public override object GetPropertyOwner(PropertyDescriptor pd)
        {
            return KeyValues;
        }


        #region Property Editing

        /// <summary>
        /// Attribute of DataItem</summary>
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        public class PropertyEditingAttribute : Attribute
        {
        }

        /// <summary>
        /// PropertyDescriptor with additional information</summary>
        public class PropertyPropertyDescriptor : PropertyDescriptor
        {
            /// <summary>
            /// Constructor</summary>
            /// <param name="property">PropertyInfo for property</param>
            /// <param name="ownerType">Owning type</param>
            public PropertyPropertyDescriptor(PropertyInfo property, Type ownerType)
                : base(property.Name, (Attribute[])property.GetCustomAttributes(typeof(Attribute), true))
            {
                m_property = property;
                m_ownerType = ownerType;
            }

            /// <summary>
            /// Gets owning type</summary>
            public Type OwnerType
            {
                get { return m_ownerType; }
            }

            /// <summary>
            /// Gets PropertyInfo for property</summary>
            public PropertyInfo Property
            {
                get { return m_property; }
            }

            /// <summary>
            /// Gets whether this property is read-only</summary>
            public override bool IsReadOnly
            {
                get { return GetChildProperties().Count <= 0; }
            }

            /// <summary>
            /// Returns whether resetting an object changes its value</summary>
            /// <param name="component">Component to test for reset capability</param>
            /// <returns>Whether resetting a component changes its value</returns>
            public override bool CanResetValue(object component)
            {
                return false;
            }

            /// <summary>
            /// Resets the value for this property of the component to the default value</summary>
            /// <param name="component"></param>
            public override void ResetValue(object component)
            {
            }

            /// <summary>
            /// Determines whether the value of this property needs to be persisted</summary>
            /// <param name="component">Component with the property to be examined for persistence</param>
            /// <returns>True iff the property should be persisted</returns>
            public override bool ShouldSerializeValue(object component)
            {
                return true;
            }

            /// <summary>
            /// Gets the type of the component this property is bound to</summary>
            public override Type ComponentType
            {
                get { return m_property.DeclaringType; }
            }

            /// <summary>
            /// Gets the type of the property</summary>
            public override Type PropertyType
            {
                get { return m_property.PropertyType; }
            }

            /// <summary>
            /// Gets the current value of property on component</summary>
            /// <param name="component">Component with the property value that is to be set</param>
            /// <returns>New value</returns>
            public override object GetValue(object component)
            {

                return m_property.GetValue(component, null);
            }

            /// <summary>
            /// Sets the value of the component to a different value</summary>
            /// <param name="component">Component with the property value that is to be set</param>
            /// <param name="value">New value</param>
            public override void SetValue(object component, object value)
            {
                m_property.SetValue(component, value, null);

                ItemChanged.Raise(component, EventArgs.Empty);
            }

            /// <summary>
            /// Gets an editor of the specified type</summary>
            /// <param name="editorBaseType">The base type of editor, 
            /// which is used to differentiate between multiple editors that a property supports</param>
            /// <returns>Instance of the requested editor type, or null if an editor cannot be found</returns>
            public override object GetEditor(Type editorBaseType)
            {
                if (m_property.PropertyType.Equals(typeof(IEnumerable<KeyValue>)))
                    return new EmbeddedCollectionEditor();
                
                return base.GetEditor(editorBaseType);
            }

            /// <summary>
            /// Event that is raised after an item changed</summary>
            public event EventHandler ItemChanged;

            private readonly Type m_ownerType;
            private readonly PropertyInfo m_property;

            private NestedCollectionEditor m_nestedCollectionEditor;
        }

       

       
        #endregion
    }
}
