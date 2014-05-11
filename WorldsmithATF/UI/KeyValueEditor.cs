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
using Sce.Atf.Adaptation;
using System.Windows.Forms;

using PropertyGrid = Sce.Atf.Controls.PropertyEditing.PropertyGrid;
using WorldsmithATF.Documents;
using System.Drawing;

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
        IDocumentRegistry documentRegstiry;
        IDocumentService documentService;

        DocumentClientInfo documentInfo;
      

        [ImportingConstructor]
        public KeyValueEditor(ICommandService commandService, 
            IControlHostService controlHostService, 
            IContextRegistry contextRegistry, 
            IDocumentRegistry documentRegstiry,
            IDocumentService documentService)
        {
            this.commandService = commandService;
            this.contextRegistry = contextRegistry;
            this.controlHostService = controlHostService;
            this.documentRegstiry = documentRegstiry;
            this.documentService = documentService;

            documentInfo = new DocumentClientInfo("KVDocument", (string)null, null, null, true);
            

        }

        public void OpenKVDocument(Project.KVFile KeyValueFile)
        {


            string path = KeyValueFile.Path;
            if(KeyValueFile.InGCF)
            {
                path = "vpk:\\" + path;
            }

            Uri uri = new Uri(path);

            IDocument doc = documentRegstiry.GetDocument(uri);

            if (doc != null) Show(doc);
            else Open(uri);
            
        }

      
        public void Initialize()
        {

        }

        public void Dispose()
        {
            
        }

        public void Activate(Control control)
        {
            if (control.Tag is KVDocument)
            {
                IDocument doc = (IDocument)control.Tag;
                
                documentRegstiry.ActiveDocument = doc;
                
            }
        }

        public bool Close(Control control)
        {
            KVDocument document = control.Tag as KVDocument;
            if (document != null)
                return documentService.Close(document);

            return true;
        }

        public void Deactivate(Control control)
        {

        }



        public bool CanOpen(Uri uri)
        {
            return true;
        }
        public IDocument Open(Uri uri)
        {
            KVDocument KVDoc = new KVDocument(uri);

            controlHostService.RegisterControl(KVDoc.DisplayControl, KVDoc.ControlInfo, this);

            KVDoc.KVTreeView.SelectionChanged += KVTreeView_SelectionChanged;
            KVDoc.OnRightClick += Control_MouseUp;
            
            return KVDoc;
        }

        [ImportMany]
        private IEnumerable<Lazy<IContextMenuCommandProvider>> commandMenuProviders;

        void Control_MouseUp(object sender, MouseEventArgs e)
        {
          
            var doc = sender as KVDocument;

            IEnumerable<object> commands = commandMenuProviders.GetCommands(sender, contextRegistry.ActiveContext);

            Point screenPoint = doc.ControlInfo.Control.PointToScreen(new Point(e.X, e.Y));

            commandService.RunContextMenu(commands, screenPoint);
            
        }

        void KVTreeView_SelectionChanged(object sender, EventArgs e)
        {
            var kvtv = sender as KeyValueTreeView;
            contextRegistry.ActiveContext = kvtv.Selection.First();
        }


        public void Close(IDocument document)
        {
             KVDocument kvdoc = document as KVDocument;
             if (kvdoc != null) controlHostService.UnregisterControl(kvdoc.DisplayControl);
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
            if (kvdoc != null) controlHostService.Show(kvdoc.DisplayControl);
        }
    }
}
