using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sce.Atf;
using Sce.Atf.Adaptation;
using Sce.Atf.Applications;
using Sce.Atf.Controls;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using WorldsmithATF.Project;


namespace WorldsmithATF.UI
{

    /// <summary>
    /// Displays a tree view of the DOM data. </summary>
    [Export(typeof(IInitializable))]
    [Export(typeof(ProjectTreeLister))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    class ProjectTreeLister : TreeControlEditor, IControlHostClient, IInitializable
    {


         /// <summary>
        /// Constructor</summary>
        /// <param name="commandService">Command service</param>
        /// <param name="controlHostService">Control host service</param>
        /// <param name="contextRegistry">Context registry</param>
        /// <param name="documentRegistry">Document registry</param>
        /// <param name="documentService">Document service</param>
        [ImportingConstructor]
        public ProjectTreeLister(
            ICommandService commandService,
            IControlHostService controlHostService,
            IContextRegistry contextRegistry,
            IDocumentRegistry documentRegistry,
            IDocumentService documentService)
            : base(commandService)
        {
            m_controlHostService = controlHostService;
            m_contextRegistry = contextRegistry;
            m_documentRegistry = documentRegistry;

            // the tree control always displays the contents of the active document
            //m_documentRegistry.ActiveDocumentChanged += new EventHandler(documentRegistry_ActiveDocumentChanged);

            m_documentService = documentService;
        }
        private IControlHostService m_controlHostService;
        private IContextRegistry m_contextRegistry;
        private IDocumentRegistry m_documentRegistry;
        private IDocumentService m_documentService;


        protected override void Configure(out TreeControl treeControl, out TreeControlAdapter treeControlAdapter)
        {
            base.Configure(out treeControl, out treeControlAdapter);

            treeControl.ShowRoot = false; // Project node can't really be edited, so hide it
            treeControl.Text = Localizer.Localize(
                "View the project in this control");
            treeControl.Dock = DockStyle.Fill;
            treeControl.AllowDrop = false;
            treeControl.SelectionMode = SelectionMode.MultiExtended;
        }

        public void Initialize()
        {
            // on initialization, register our tree control with the hosting service
            m_controlHostService.RegisterControl(
                TreeControl,
                new ControlInfo(
                   Localizer.Localize("Project"),
                   Localizer.Localize("Displays the project"),
                   StandardControlGroup.Left), // don't show close button
               this);
        }

        public void Activate(Control control)
        {
            // on control activation, make the UI the active context and document
            if (TreeView != null)
            {
                m_contextRegistry.ActiveContext = TreeView;
                m_documentRegistry.ActiveDocument = Adapters.As<ProjectDocument>(TreeView);
            }
        }

        public bool Close(Control control)
        {
            bool closed = true;

            // Get current document, if any
            ProjectDocument document = Adapters.As<ProjectDocument>(TreeView);

            // Check if document can be closed
            if (document != null)
            {
                closed = m_documentService.Close(document);
                if (closed)
                    m_contextRegistry.RemoveContext(document);
            }

            return closed;  // app must be closing
        }

        public void Deactivate(Control control)
        {            
        }
    }
}
