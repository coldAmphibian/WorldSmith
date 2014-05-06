using Sce.Atf;
using Sce.Atf.Dom;
using Sce.Atf.Adaptation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using WorldsmithATF.ObjectTypes;

using PropertyDescriptor = Sce.Atf.Dom.PropertyDescriptor;
using Sce.Atf.Controls.PropertyEditing;
using KVLib;
using WorldsmithATF.TypeDescriptors;

namespace WorldsmithATF
{
    [Export(typeof(SchemaLoader))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    class SchemaLoader : XmlSchemaTypeLoader
    {
        /// <summary>
        /// Loads the UI schema, registers data extensions on the DOM types, annotates
        /// the types with display information and PropertyDescriptors.</summary>
        public SchemaLoader()
        {
            SchemaResolver = new ResourceStreamResolver(Assembly.GetExecutingAssembly(), "WorldsmithATF/DOMSchema");
            Load("DotaObjects.xsd");
        }


        public string NameSpace
        {
            get;
            private set;
        }


        public XmlSchemaTypeCollection TypeCollection
        {
            get;
            private set;
        }

        protected override void OnSchemaSetLoaded(XmlSchemaSet schemaSet)
        {
            foreach(XmlSchemaTypeCollection typeCollection in GetTypeCollections())
            {
                NameSpace = typeCollection.TargetNamespace;
                TypeCollection = typeCollection;
                DotaObjectsSchema.Initialize(TypeCollection);

                // register UI adapters as extensions on the DOM data

                // Register adapters for the Documents
                
                 

                //Register the adapters for the Project object model
                DotaObjectsSchema.ProjectType.Type.Define(new ExtensionInfo<Project.AddonProject>());
                DotaObjectsSchema.FileType.Type.Define(new ExtensionInfo<Project.ProjectFile>());
                DotaObjectsSchema.FolderType.Type.Define(new ExtensionInfo<Project.ProjectFolder>());
                DotaObjectsSchema.TextFileType.Type.Define(new ExtensionInfo<Project.TextFile>());
                DotaObjectsSchema.KVDocumentType.Type.Define(new ExtensionInfo<Project.KVFile>());
                DotaObjectsSchema.LuaDocumentType.Type.Define(new ExtensionInfo<Project.LuaFile>());
                DotaObjectsSchema.VMTType.Type.Define(new ExtensionInfo<Project.VMTFile>());


                // register adapters to define the Dota object model
                DotaObjectsSchema.DotaDataObjectType.Type.Define(new ExtensionInfo<DotaDataObject>());
                DotaObjectsSchema.DotaBaseUnitType.Type.Define(new ExtensionInfo<DotaBaseUnit>());
                DotaObjectsSchema.DotaUnitType.Type.Define(new ExtensionInfo<DotaUnit>());
                DotaObjectsSchema.DotaHeroType.Type.Define(new ExtensionInfo<DotaHero>());

                //Register the EditingContext
                DotaObjectsSchema.ProjectType.Type.Define(new ExtensionInfo<DotaEditingContext>());
                DotaObjectsSchema.FileType.Type.Define(new ExtensionInfo<DotaEditingContext>());
                DotaObjectsSchema.FolderType.Type.Define(new ExtensionInfo<DotaEditingContext>());
                DotaObjectsSchema.TextFileType.Type.Define(new ExtensionInfo<DotaEditingContext>());
                DotaObjectsSchema.KVDocumentType.Type.Define(new ExtensionInfo<DotaEditingContext>());
                DotaObjectsSchema.LuaDocumentType.Type.Define(new ExtensionInfo<DotaEditingContext>());
                DotaObjectsSchema.VMTType.Type.Define(new ExtensionInfo<DotaEditingContext>());


                OverrideProperty(typeof(KeyValue), "Key");
                OverrideProperty(typeof(KeyValue), "Children", new PropertyEditorAttribute(typeof(NestedCollectionEditor)));
                //OverrideProperty(typeof(KeyValue), "Children");
                
                break; //Only one namespace
            }
        }

        //Property overriding taken from 
        //http://stackoverflow.com/questions/12143650/how-to-add-property-level-attribute-to-the-typedescriptor-at-runtime
        private void OverrideProperty(Type type, string PropertyName, params Attribute[] attributes)
        {
            //Override the KeyValue type descriptors
            // prepare our property overriding type descriptor
            PropertyOverridingTypeDescriptor ctd = new PropertyOverridingTypeDescriptor(TypeDescriptor.GetProvider(type).GetTypeDescriptor(type));

            // iterate through properies in the supplied object/type
            foreach (System.ComponentModel.PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(KeyValue)))
            {
                // for every property that complies to our criteria
                if (pd.Name == PropertyName)
                {
                    // we first construct the custom PropertyDescriptor with the TypeDescriptor's
                    // built-in capabilities
                    System.ComponentModel.PropertyDescriptor pd2 =
                        TypeDescriptor.CreateProperty(
                            type, // or just _settings, if it's already a type
                            pd, // base property descriptor to which we want to add attributes
                        // The PropertyDescriptor which we'll get will just wrap that
                        // base one returning attributes we need.
                            attributes
                        // this method really can take as many attributes as you like,
                        // not just one
                        );

                    // and then we tell our new PropertyOverridingTypeDescriptor to override that property
                    ctd.OverrideProperty(pd2);
                }
            }

            // then we add new descriptor provider that will return our descriptor istead of default
            TypeDescriptor.AddProvider(new TypeDescriptorOverridingProvider(ctd), type);
        }


        protected override void ParseAnnotations(XmlSchemaSet schemaSet, IDictionary<NamedMetadata, IList<System.Xml.XmlNode>> annotations)
        {
            base.ParseAnnotations(schemaSet, annotations);

            IList<XmlNode> xmlNodes;

            foreach (DomNodeType nodeType in TypeCollection.GetNodeTypes())
            {
                // Parse XML annotation for property descriptors
                if (annotations.TryGetValue(nodeType, out xmlNodes))
                {
                    PropertyDescriptorCollection propertyDescriptors = Sce.Atf.Dom.PropertyDescriptor.ParseXml(nodeType, xmlNodes);
                    if (propertyDescriptors != null && propertyDescriptors.Count > 0)
                    {
                        // Property descriptor annotation found. Add any descriptors already set for this type.
                        PropertyDescriptorCollection propertyDescriptorsAlreadySet = nodeType.GetTag<PropertyDescriptorCollection>();
                        if (propertyDescriptorsAlreadySet != null)
                            foreach (PropertyDescriptor desc in propertyDescriptorsAlreadySet)
                                propertyDescriptors.Add(desc);
                        // Set all property descriptors
                        nodeType.SetTag<PropertyDescriptorCollection>(propertyDescriptors);
                    }
                }
            }
        }

    }
}
