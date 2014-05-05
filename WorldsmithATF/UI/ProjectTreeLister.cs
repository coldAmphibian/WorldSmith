//Copyright © 2014 Sony Computer Entertainment America LLC. See License.txt.

using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Linq;

using Sce.Atf;
using Sce.Atf.Adaptation;
using Sce.Atf.Applications;
using Sce.Atf.Controls;
using Sce.Atf.Controls.PropertyEditing;
using WorldsmithATF.Project;
using Sce.Atf.Dom;
using System.Collections.Generic;
using System.Drawing;

namespace WorldsmithATF.UI
{
    /// <summary>
    /// Displays a tree view of the DOM data. Uses the context registry to track
    /// the active UI data as documents are opened and closed.</summary>
    [Export(typeof(IInitializable))]
    [Export(typeof(ProjectTreeLister))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ProjectTreeLister : TreeControlEditor, IControlHostClient, IInitializable
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
            ISettingsService settings,
            TextEditing.TextEditor textEditor
          )
            : base(commandService)
        {
            this.commandService = commandService;
            m_controlHostService = controlHostService;
            m_contextRegistry = contextRegistry;
            this.settings = settings;
            this.textEditor = textEditor;

            this.TreeControl.ImageList = ResourceUtil.GetImageList16();

           
        }

        private ICommandService commandService;
        private IControlHostService m_controlHostService;
        private IContextRegistry m_contextRegistry;
        private ISettingsService settings;

        private TextEditing.TextEditor textEditor;

        [ImportMany]
        private IEnumerable<Lazy<IContextMenuCommandProvider>> commandMenuProviders = null;


        public void OpenProject(AddonProject project)
        {           

            ProjectView pv = TreeView as ProjectView;
            pv.Root = project;

            TreeView = pv; //When changing the root node, it doesn't update unless I do this.  No idea why

            SettingsService service = this.settings as SettingsService;
            service.SaveSettings();

        }

        void TreeControl_DoubleClick(object sender, EventArgs e)
        {
            ProjectView view = TreeView as ProjectView;
            object selection = view.Selection.FirstOrDefault();

            if (selection != null && selection.Is<Project.TextFile>())
            {
                TextFile f = selection.As<TextFile>();
                textEditor.OpenDocument(f);

            }
        }

    

        protected override void Configure(out TreeControl treeControl, out TreeControlAdapter treeControlAdapter)
        {
            base.Configure(out treeControl, out treeControlAdapter);

            treeControl.ShowRoot = false; // hide root node, because it's the project
            treeControl.Text = Localizer.Localize("No Project Loaded");
            treeControl.Dock = DockStyle.Fill;
            treeControl.AllowDrop = true;
            treeControl.SelectionMode = SelectionMode.One;   
        }

      
        #region IControlHostClient Members

        /// <summary>
        /// Notifies the client that its Control has been activated. Activation occurs when
        /// the Control gets focus, or a parent "host" Control gets focus.</summary>
        /// <param name="control">Client Control that was activated</param>
        /// <remarks>This method is only called by IControlHostService if the Control was previously
        /// registered for this IControlHostClient.</remarks>
        public void Activate(Control control)
        {
          
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
            return true;
        }

        #endregion

        #region IInitializable Members

        void IInitializable.Initialize()
        {
            // on initialization, register our tree control with the hosting service
            m_controlHostService.RegisterControl(
                TreeControl,
                new ControlInfo(
                   Localizer.Localize("Addon Explorer"),
                   Localizer.Localize("Displays the current addon"),
                   StandardControlGroup.Left), // don't show close button
               this);


            BoundPropertyDescriptor[] settings = new BoundPropertyDescriptor[] {
                new BoundPropertyDescriptor(typeof(GlobalSettings), 
                    () => GlobalSettings.CurrentProjectDirectory, "Current Project Directory", "Paths", "Path to current addon project.  Dont mess with this"),

                   
            };

            this.settings.RegisterSettings(this, settings);

            TreeView = new ProjectView();
            this.TreeControl.DoubleClick += TreeControl_DoubleClick;

            SettingsService service = this.settings as SettingsService;
            service.LoadSettings();
            if(GlobalSettings.CurrentProjectDirectory != null)
            {
                OpenProject(ProjectLoader.OpenProjectFromFolder(GlobalSettings.CurrentProjectDirectory));
            }
            (TreeView as ProjectView).SelectionChanged += view_SelectionChanged;

            TreeControl.MouseUp += TreeControl_MouseUp;
           
        }

        void TreeControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeControl control = sender as TreeControl;

                IEnumerable<object> commands = commandMenuProviders.GetCommands(null, null);

                Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));

                commandService.RunContextMenu(commands, screenPoint);

            }
        }

        private void view_SelectionChanged(object sender, EventArgs e)
        {
            m_contextRegistry.ActiveContext = (TreeView as ProjectView).Selection.FirstOrDefault().As<DomNode>();
        }
      

        #endregion

    }
}
