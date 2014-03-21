using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using Sce.Atf;
using Sce.Atf.Adaptation;
using Sce.Atf.Applications;

using WorldsmithATF.UI;
using System.Windows.Forms;
using System.IO;


namespace WorldsmithATF.Commands
{

    enum ProjectCommandTags
    {
        CreateNewProject,
        OpenProject,

    }


    [Export(typeof(IInitializable))]
    [Export(typeof(ProjectCommands))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    class ProjectCommands : ICommandClient, IInitializable
    {

        ProjectTreeLister projectLister;
        ICommandService commandService;

        [ImportingConstructor]
        public ProjectCommands(ProjectTreeLister project, ICommandService service)
        {
            projectLister = project;
            commandService = service;
        }

        public void Initialize()
        {
            commandService.RegisterCommand(ProjectCommandTags.CreateNewProject,
                StandardMenu.File,
                StandardCommandGroup.FileNew,
                "New Addon",
                "Create a new Addon",
                this);

            commandService.RegisterCommand(ProjectCommandTags.OpenProject,
                StandardMenu.File,
                StandardCommandGroup.FileNew,
                "Open Addon",
                "Open an addon in your Dota directory",
                this);


        }

        public bool CanDoCommand(object commandTag)
        {
            return true;
        }

        public void DoCommand(object commandTag)
        {
            ProjectCommandTags tag = (ProjectCommandTags) commandTag;
            switch(tag)
            {
                case ProjectCommandTags.OpenProject:
                    OpenProject();
                    break;

                case ProjectCommandTags.CreateNewProject:
                    break;
            }
        }

        public void OpenProject()
        {
            if(GlobalSettings.DotaDirectory == null)
            {
                MessageBox.Show("Please set the dota directory in preferences!");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = GlobalSettings.DotaDirectory + Path.DirectorySeparatorChar + "dota" +
                Path.DirectorySeparatorChar + "addons";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            string folder = dialog.SelectedPath + Path.DirectorySeparatorChar;

            if (!File.Exists(folder + "addoninfo.txt"))
            {
                MessageBox.Show("That's not an addon folder!\nSelect a folder with an addoninfo.txt", "Invalid Folder", MessageBoxButtons.OK);
                return;
            }

           
            projectLister.OpenProject(folder);
           

        }

        public void UpdateCommand(object commandTag, CommandState commandState)
        {
            
        }


    }
}
