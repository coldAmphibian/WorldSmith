using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using Sce.Atf;
using Sce.Atf.Dom;
using Sce.Atf.Applications;
using Sce.Atf.Controls.PropertyEditing;
using System.Windows.Forms;

using PropertyGrid = Sce.Atf.Controls.PropertyEditing.PropertyGrid;
using WorldsmithATF.Documents;

namespace WorldsmithATF.UI
{
    [Export(typeof(KeyValueEditor))]
    [Export(typeof(IInitializable))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Any)]
    class KeyValueEditor : IInitializable, IControlHostClient, IDisposable, IDocumentClient
    {
        ICommandService commandService;
        IControlHostService controlHostService;
        IContextRegistry contextRegistry;

        DocumentClientInfo documentInfo;
      

        [ImportingConstructor]
        public KeyValueEditor(ICommandService commandService, IControlHostService controlHostService, IContextRegistry contextRegistry)
        {
            this.commandService = commandService;
            this.contextRegistry = contextRegistry;
            this.controlHostService = controlHostService;

            documentInfo = new DocumentClientInfo("KVDocument", ".txt", null, null);

        }

        public void OpenKVDocument(Project.KVFile KeyValueFile)
        {
            string path = KeyValueFile.Path;
            if(KeyValueFile.InGCF)
            {
                path = "vpk:\\" + path;
            }
            Open(new Uri(path));
        }

      
        public void Initialize()
        {

        }

        public void Dispose()
        {
            
        }

        public void Activate(Control control)
        {           
        }

        public bool Close(Control control)
        {
            return true;
        }

        public void Deactivate(Control control)
        {

        }



        public bool CanOpen(Uri uri)
        {
            return documentInfo.IsCompatibleUri(uri);
        }
        public IDocument Open(Uri uri)
        {
            KVDocument KVDoc = new KVDocument(uri);

            controlHostService.RegisterControl(KVDoc.PropertyGrid, KVDoc.ControlInfo, this);

            return KVDoc;
        }

        public void Close(IDocument document)
        {
             KVDocument kvdoc = document as KVDocument;
             if (kvdoc != null) controlHostService.UnregisterControl(kvdoc.PropertyGrid);
        }

        public DocumentClientInfo Info
        {
            get { return documentInfo; }
        }
        
        public void Save(IDocument document, Uri uri)
        {
            KVDocument kvdoc = document as KVDocument;
            if (kvdoc != null) kvdoc.Save();
        }

        public void Show(IDocument document)
        {
            KVDocument kvdoc = document as KVDocument;
            if (kvdoc != null) controlHostService.Show(kvdoc.PropertyGrid);
        }
    }
}
