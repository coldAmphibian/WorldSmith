using Sce.Atf;
using Sce.Atf.Dom;
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

                // register adapters on the root to define document and editing context
                 

                //Register the adapters for the Project object model
                DotaObjectsSchema.ProjectType.Type.Define(new ExtensionInfo<Project.AddonProject>());
                DotaObjectsSchema.FileType.Type.Define(new ExtensionInfo<Project.ProjectFile>());
                DotaObjectsSchema.FolderType.Type.Define(new ExtensionInfo<Project.ProjectFolder>());
                DotaObjectsSchema.TextFileType.Type.Define(new ExtensionInfo<Project.TextFile>());
                DotaObjectsSchema.KVDocumentType.Type.Define(new ExtensionInfo<Project.KVFile>());


                // register adapters to define the Dota object model
                DotaObjectsSchema.DotaDataObjectType.Type.Define(new ExtensionInfo<DotaDataObject>());
                DotaObjectsSchema.DotaBaseUnitType.Type.Define(new ExtensionInfo<DotaBaseUnit>());
                DotaObjectsSchema.DotaUnitType.Type.Define(new ExtensionInfo<DotaUnit>());
                DotaObjectsSchema.DotaHeroType.Type.Define(new ExtensionInfo<DotaHero>());

                break; //Only one namespace
            }
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
