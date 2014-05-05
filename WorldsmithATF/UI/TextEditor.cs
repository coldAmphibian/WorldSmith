using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;

using Sce.Atf;
using Sce.Atf.Applications;
using WorldsmithATF.Project;
using WorldsmithATF.Documents;

namespace WorldsmithATF.TextEditing
{
    /// <summary>
    /// Code editor component</summary>
    [Export(typeof(IInitializable))]
    [Export(typeof(TextEditor))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class TextEditor : IControlHostClient, IInitializable, ICommandClient
    {
        /// <summary>
        /// Constructor</summary>
        /// <param name="commandService">Command service</param>
        /// <param name="controlHostService">Control host service</param>
        /// <param name="documentService">Document service</param>
        /// <param name="documentRegistry">Document registry used to track documents</param>
        /// <param name="fileDialogService">File dialog service</param>
        [ImportingConstructor]
        public TextEditor(
            ICommandService commandService,
            IControlHostService controlHostService,
            IDocumentService documentService,
            IDocumentRegistry documentRegistry,
            IFileDialogService fileDialogService,
            DotaVPKService vpkService
            )
        {
            m_commandService = commandService;
            m_controlHostService = controlHostService;
            m_documentService = documentService;
            m_documentRegistry = documentRegistry;
            m_fileDialogService = fileDialogService;
            this.vpkService = vpkService;
            // create a document client for each file type
            m_txtDocumentClient = new DocumentClient(this, ".txt");           
            m_luaDocumentClient = new DocumentClient(this, ".lua");    
      
            

        }

        [Import(AllowDefault = true)]
        private IStatusService m_statusService = null;

        [Import(AllowDefault = true)]
        private SourceControlService m_sourceControlService = null;

        [Export(typeof(IDocumentClient))]
        private DocumentClient m_txtDocumentClient;
     
        [Export(typeof(IDocumentClient))]
        private DocumentClient m_luaDocumentClient;

        private DotaVPKService vpkService;

      

        /// <summary>
        /// Creates an IDocumentClient object with the specified extension.
        /// This is used by automated tests to create new documents.</summary>
        /// <param name="extension">Document extension</param>
        /// <returns>IDocumentClient object</returns>
        public IDocumentClient CreateNewDocument(string extension)
        {
            return new DocumentClient(this, extension);
        }

        public IDocument OpenDocument(Project.TextFile file, bool sourceTag = false)
        {   
             string path = file.Path;

            if(file.InGCF)
            {
                //Formatting the path for use with the Uri class
                path = "VPK:\\" + path;
            }
            Uri uri = new Uri(path);
            IDocument cl = m_documentRegistry.GetDocument(uri);
            if (cl != null) return cl;

           
            string ext = System.IO.Path.GetExtension(path);

            if(ext == ".lua")
            {
                return m_luaDocumentClient.Open(uri, file.InGCF);
            }
          
            return m_txtDocumentClient.Open(uri, file.InGCF, sourceTag);           

        }

        // scripting related members
        [Import(AllowDefault = true)]
        private ScriptingService m_scriptingService = null;

        #region IInitializable Members

        public void Initialize()
        {
            

            // register commands
            m_commandService.RegisterCommand(CommandInfo.EditUndo, this);
            m_commandService.RegisterCommand(CommandInfo.EditRedo, this);
            m_commandService.RegisterCommand(CommandInfo.EditCut, this);
            m_commandService.RegisterCommand(CommandInfo.EditCopy, this);
            m_commandService.RegisterCommand(CommandInfo.EditPaste, this);
            m_commandService.RegisterCommand(CommandInfo.EditDelete, this);

            m_commandService.RegisterCommand(
                Command.FindReplace,
                StandardMenu.Edit,
                StandardCommandGroup.EditOther,
                "Find and Replace...",
                "Find and replace text",
                Keys.Control | Keys.F,
                Resources.FindImage,
                CommandVisibility.Menu,
                this);

            m_commandService.RegisterCommand(
                Command.Goto,
                StandardMenu.Edit,
                StandardCommandGroup.EditOther,
                "Go to...",
                "Go to line",
                Keys.Control | Keys.G,
                null,
                CommandVisibility.Menu,
                this);

            if (m_scriptingService != null)
            {
                // load this assembly into script domain.
                m_scriptingService.LoadAssembly(GetType().Assembly);
                m_scriptingService.ImportAllTypes("CodeEditor");
                m_scriptingService.SetVariable("editor", this);
            }

            if (m_sourceControlService != null)
            {
                m_sourceControlService.StatusChanged += SourceControl_StatusChanged;
                m_sourceControlService.EnabledChanged += SourceControlService_EnabledChanged;
            }
            m_documentRegistry.DocumentAdded += DocumentRegistry_DocumentAdded;

            
        }


        #endregion

        #region IControlHostClient Members

        /// <summary>
        /// Notifies the client that its Control has been activated. Activation occurs when
        /// the Control gets focus, or a parent "host" Control gets focus.</summary>
        /// <param name="control">Client Control that was activated</param>
        /// <remarks>This method is only called by IControlHostService if the Control was previously
        /// registered for this IControlHostClient.</remarks>
        public void Activate(Control control)
        {
            if (control.Tag is CodeDocument)
            {
                IDocument doc = (IDocument)control.Tag;
                m_documentRegistry.ActiveDocument = doc;
                m_commandService.SetActiveClient(this);
            }
        }

        /// <summary>
        /// Notifies the client that its Control has been deactivated. Deactivation occurs when
        /// another Control or "host" Control gets focus.</summary>
        /// <param name="control">Client Control that was deactivated</param>
        /// <remarks>This method is only called by IControlHostService if the Control was previously
        /// registered for this IControlHostClient.</remarks>
        public void Deactivate(Control control)
        {
        }

        /// <summary>
        /// Requests permission to close the client's Control</summary>
        /// <param name="control">Client Control to be closed</param>
        /// <returns>True if the Control can close, or false to cancel</returns>
        /// <remarks>
        /// 1. This method is only called by IControlHostService if the Control was previously
        /// registered for this IControlHostClient.
        /// 2. If true is returned, the IControlHostService calls its own
        /// UnregisterControl. The IControlHostClient has to call RegisterControl again
        /// if it wants to re-register this Control.</remarks>
        public bool Close(Control control)
        {
            CodeDocument document = control.Tag as CodeDocument;
            if (document != null)
                return m_documentService.Close(document);

            return true;
        }

        #endregion

        #region ICommandClient Members

        /// <summary>
        /// Checks whether the client can do the command, if it handles it</summary>
        /// <param name="commandTag">Command to be done</param>
        /// <returns>True iff client can do the command</returns>
        public bool CanDoCommand(object commandTag)
        {
            bool canDo = false;
            CodeDocument doc = m_documentRegistry.ActiveDocument as CodeDocument;
            if (commandTag is StandardCommand)
            {
                if (doc != null)
                {
                    switch ((StandardCommand)commandTag)
                    {
                        case StandardCommand.EditUndo:
                            canDo = doc.Editor.CanUndo;
                            break;

                        case StandardCommand.EditRedo:
                            canDo = doc.Editor.CanRedo;
                            break;

                        case StandardCommand.EditCut:
                        case StandardCommand.EditDelete:
                            canDo = doc.Editor.HasSelection && !doc.Editor.ReadOnly;
                            break;

                        case StandardCommand.EditCopy:
                            canDo = doc.Editor.HasSelection;
                            break;

                        case StandardCommand.EditPaste:
                            canDo = doc.Editor.CanPaste;
                            break;
                    }
                }
            }
            else if (commandTag is Command)
            {
                switch ((Command)commandTag)
                {
                    case Command.Goto:
                    case Command.FindReplace:
                        canDo = doc != null;
                        break;

                    default:
                        canDo = true;
                        break;

                }
            }

            return canDo;
        }

        /// <summary>
        /// Does the command</summary>
        /// <param name="commandTag">Command to be done</param>
        public void DoCommand(object commandTag)
        {
            CodeDocument activeDocument = m_documentRegistry.ActiveDocument as CodeDocument;
            if (commandTag is StandardCommand)
            {
                switch ((StandardCommand)commandTag)
                {
                    case StandardCommand.EditUndo:
                        activeDocument.Editor.Undo();
                        break;

                    case StandardCommand.EditRedo:
                        activeDocument.Editor.Redo();
                        break;

                    case StandardCommand.EditCut:
                        activeDocument.Editor.Cut();
                        break;

                    case StandardCommand.EditCopy:
                        activeDocument.Editor.Copy();
                        break;

                    case StandardCommand.EditPaste:
                        activeDocument.Editor.Paste();
                        break;

                    case StandardCommand.EditDelete:
                        activeDocument.Editor.Delete();
                        break;
                }
            }
            else if (commandTag is Command)
            {
                switch ((Command)commandTag)
                {
                    case Command.FindReplace:
                        activeDocument.Editor.ShowFindReplaceForm();
                        break;

                    case Command.Goto:
                        activeDocument.Editor.ShowGoToLineForm();
                        break;
                }
            }
        }

        /// <summary>
        /// Updates command state for given command</summary>
        /// <param name="commandTag">Command</param>
        /// <param name="commandState">Command info to update</param>
        public void UpdateCommand(object commandTag, CommandState commandState)
        {
        }

        #endregion

        private void ShowStatus(string message)
        {
            if (m_statusService != null)
                m_statusService.ShowStatus(message);
        }

        // update source control status icon on the document tab
        private void SourceControl_StatusChanged(object sender, SourceControlEventArgs e)
        {
            var document = m_documentRegistry.GetDocument(e.Uri) as CodeDocument;
            if (document == null)
                return;
            document.ControlInfo.Image = m_sourceControlService.GetSourceControlStatusIcon(e.Uri, e.Status);
            if (e.Status == SourceControlStatus.CheckedIn)
                document.Read();
        }

        // update source control status icon on the document tab
        void SourceControlService_EnabledChanged(object sender, EventArgs e)
        {
            foreach (var document in m_documentRegistry.Documents)
            {
                var codeDocument = document as CodeDocument;
                if (codeDocument != null)
                {
                    codeDocument.ControlInfo.Image = m_sourceControlService.GetSourceControlStatusIcon(document.Uri,
                                                          m_sourceControlService.GetStatus(document.Uri));
                }

            }
        }

        // update source control status icon on the document tab
        void DocumentRegistry_DocumentAdded(object sender, ItemInsertedEventArgs<IDocument> e)
        {
            if (m_sourceControlService == null || !m_sourceControlService.Enabled)
                return;

            var document = m_documentRegistry.ActiveDocument as CodeDocument;
            if (document != null)
            {
                document.ControlInfo.Image = m_sourceControlService.GetSourceControlStatusIcon(document.Uri,
                                                            m_sourceControlService.GetStatus(document.Uri));
            }
        }

        private enum Command
        {
            FindReplace,
            Goto
        }



        /// <summary>
        /// Document client, so we can export one for each file type</summary>
        private class DocumentClient : IDocumentClient
        {
            public DocumentClient(TextEditor editor, string extension)
            {
                m_editor = editor;
                string fileType = CodeDocument.GetDocumentType(extension);
                m_info = new DocumentClientInfo(fileType, extension, null, null);
                
            }
            private TextEditor m_editor;
            private DocumentClientInfo m_info;

            #region IDocumentClient Members

            public DocumentClientInfo Info
            {
                get { return m_info; }
            }

            public bool CanOpen(Uri uri)
            {
                return m_info.IsCompatibleUri(uri);
            }

            public IDocument Open(Uri uri)
            {
                return Open(uri, false);
            }

            public IDocument Open(Uri uri, bool fromVPK, bool sourceTag = false)
            {
                CodeDocument doc = new CodeDocument(uri, fromVPK, sourceTag);
                if(fromVPK)
                {
                    doc.FromVPK = true;
                    doc.vpkService = m_editor.vpkService;
                }
                doc.Read();


                m_editor.m_controlHostService.RegisterControl(
                    doc.Control,
                    doc.ControlInfo,
                    m_editor);

                return doc;
            }

            public void Show(IDocument document)
            {
                CodeDocument codeDoc = document as CodeDocument;
                if (codeDoc != null)
                    m_editor.m_controlHostService.Show(codeDoc.Control);
            }

            public void Save(IDocument document, Uri uri)
            {
                CodeDocument codeDoc = document as CodeDocument;
                if (codeDoc != null)
                {
                    codeDoc.Write();
                }
            }

            public void Close(IDocument document)
            {
                CodeDocument codeDoc = document as CodeDocument;
                if (codeDoc != null)
                {
                    m_editor.m_controlHostService.UnregisterControl(codeDoc.Control);
                }
            }

            #endregion


          
        }

        private ICommandService m_commandService;
        private IControlHostService m_controlHostService;
        private IDocumentService m_documentService;
        private IDocumentRegistry m_documentRegistry;
        private IFileDialogService m_fileDialogService;
    }
}
