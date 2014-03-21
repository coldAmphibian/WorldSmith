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

using WorldsmithATF.Project;

using Project = WorldsmithATF.Project.AddonProject;
using Sce.Atf.Dom;


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

            string folder = dialog.SelectedPath;

            if (!File.Exists(folder +Path.DirectorySeparatorChar + "addoninfo.txt"))
            {
                MessageBox.Show("That's not an addon folder!\nSelect a folder with an addoninfo.txt", "Invalid Folder", MessageBoxButtons.OK);
                return;
            }
            DomNode domRoot = new DomNode(DotaObjectsSchema.ProjectType.Type);
            AddonProject project = domRoot.As<AddonProject>();
            project.Name = "adsf";

            ProjectFolder root = (new DomNode(DotaObjectsSchema.FolderType.Type)).As<ProjectFolder>();
            root.Path = folder;
            root.Name = folder.Substring(folder.LastIndexOf(Path.DirectorySeparatorChar) + 1);
           

            BuildProjectFromDirectoriesRecursive(folder, ref root);


            project.ProjectFiles.Add(root);

            projectLister.OpenProject(project);
           

        }


        public void BuildProjectFromDirectoriesRecursive(string path, ref ProjectFolder project)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                ProjectFolder folder = (new DomNode(DotaObjectsSchema.FolderType.Type)).As<ProjectFolder>();
                folder.Path = directory;
                folder.Name = directory.Substring(directory.LastIndexOf(Path.DirectorySeparatorChar) + 1);


                project.Files.Add(folder);
                BuildProjectFromDirectoriesRecursive(directory, ref folder);
            }

            foreach(string File in Directory.GetFiles(path))
            {
                string name = Path.GetFileName(File);
                ProjectFile f = (new DomNode(DotaObjectsSchema.FileType.Type)).As<ProjectFile>();
                f.Path = File;
                f.Name = name;
                

                project.Files.Add(f);

            }
           
        }


        public void UpdateCommand(object commandTag, CommandState commandState)
        {
            
        }


    }
}
