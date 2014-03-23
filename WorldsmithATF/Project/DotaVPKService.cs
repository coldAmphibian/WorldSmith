using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sce.Atf;
using Sce.Atf.Adaptation;
using Sce.Atf.Applications;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows.Forms;
using Sce.Atf.Dom;
using Sce.Atf.Controls.PropertyEditing;


namespace WorldsmithATF.Project
{
    [Export(typeof(IInitializable))]
    [Export(typeof(DotaVPKService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DotaVPKService : IInitializable
    {
        public static string VPKPath = "dota" + Path.DirectorySeparatorChar + "pak01_dir.vpk";


        SettingsService settingsService;


        [ImportingConstructor]
        public DotaVPKService(SettingsService settings)
        {
            this.settingsService = settings;
        }

        public void Initialize()
        {

            BoundPropertyDescriptor[] settings = new BoundPropertyDescriptor[] {
                new BoundPropertyDescriptor(typeof(GlobalSettings), 
                    () => GlobalSettings.DotaDirectory, "Dota 2 Directory", "Paths", "Path to dota 2 directory"),

                   
            };

            settingsService.RegisterUserSettings("Application", settings);
            settingsService.RegisterSettings(this, settings);

            //If GlobalSettings is not set, give the settings service a chance to load
            if(GlobalSettings.DotaDirectory == null)
            {
                settingsService.LoadSettings();
            }

            //if it's *still* not set, force the user to set it
            if (GlobalSettings.DotaDirectory == null)
            {
                MessageBox.Show("Your Dota 2 directory is not set.  Please set it now");
                settingsService.PresentUserSettings(null);
            }

            //Make damn sure that the dota directory is set correctly
            while (!File.Exists(GlobalSettings.DotaDirectory + Path.DirectorySeparatorChar + VPKPath))
            {
                MessageBox.Show("This does not appear to be your Dota 2 directory.  Please set the dota 2 path to your 'steamapps/common/dota 2[ beta]' directory");
                settingsService.PresentUserSettings(null);
            }

            OpenVPK();
        }

        #region Read From VPK
        public string ReadTextFromVPK(string path)
        {
            IntPtr root = HLLib.hlPackageGetRoot();

            IntPtr file = HLLib.hlFolderGetItemByPath(root, path, HLLib.HLFindType.HL_FIND_FILES);

            IntPtr stream;
            if(ErrorCheck(HLLib.hlPackageCreateStream(file, out stream)))
            {
                return "Unable to Load File";
            }

            string text = ReadTextFromHLLibStream(stream);

            return text;

        }


        private static string ReadTextFromHLLibStream(IntPtr Stream)
        {
            HLLib.HLFileMode mode = HLLib.HLFileMode.HL_MODE_READ;

            if(ErrorCheck(HLLib.hlStreamOpen(Stream, (uint)mode)))
            {
                return "Unable to Load File";
            }

            StringBuilder str = new StringBuilder();

            char ch;
            while (HLLib.hlStreamReadChar(Stream, out ch))
            {
                str.Append(ch);
            }

            HLLib.hlStreamClose(Stream);

            return str.ToString();
        }
        #endregion

        #region OpenVPK
        public static void OpenVPK()
        {
            string path = GlobalSettings.DotaDirectory + Path.DirectorySeparatorChar + VPKPath;
            HLLib.hlInitialize();

            // Get the package type from the filename extension.
            HLLib.HLPackageType PackageType = HLLib.hlGetPackageTypeFromName(path);

            HLLib.HLFileMode OpenMode = HLLib.HLFileMode.HL_MODE_READ |
                //HLLib.HLFileMode.HL_MODE_QUICK_FILEMAPPING |
                HLLib.HLFileMode.HL_MODE_VOLATILE;

            uint PackageID;

            ErrorCheck(HLLib.hlCreatePackage(PackageType, out PackageID));

            ErrorCheck(HLLib.hlBindPackage(PackageID));

            ErrorCheck(HLLib.hlPackageOpenFile(path, (uint)OpenMode));
        }




        public static bool ErrorCheck(bool ret)
        {
            if (!ret)
            {
                MessageBox.Show("Error reading pak01_dir.vpk.\n\n The error reported was: " + HLLib.hlGetString(HLLib.HLOption.HL_ERROR_LONG_FORMATED), "Error opening .pak", MessageBoxButtons.OK);
                return true;

            }
            return false;
        }

        public static void Shutdown()
        {
            HLLib.hlShutdown();
        }
        #endregion

        #region VPKDom Builder
        public ProjectFolder BuildDotaVPKNode()
        {
            ProjectFolder folder = (new DomNode(DotaObjectsSchema.FolderType.Type)).As<ProjectFolder>();

            folder.Name = "root";
            folder.Path = "root";
            folder.InGCF = true;
           
            IntPtr root = HLLib.hlPackageGetRoot();

            RecursiveBuildFromVPK(ref folder, root);


            return folder;
        }

        public void RecursiveBuildFromVPK(ref ProjectFolder folder, IntPtr currentFolder)
        {

            uint folderCount = HLLib.hlFolderGetCount(currentFolder);
            for (uint i = 0; i < folderCount; i++)
            {
                IntPtr subItem = HLLib.hlFolderGetItem(currentFolder, i);
                string name = HLLib.hlItemGetName(subItem);

                if (HLLib.hlItemGetType(subItem) == HLLib.HLDirectoryItemType.HL_ITEM_FOLDER)
                {
                    DomNode sf = new DomNode(DotaObjectsSchema.FolderType.Type);

                    sf.SetAttribute(DotaObjectsSchema.FolderType.NameAttribute, name);
                    sf.SetAttribute(DotaObjectsSchema.FolderType.PathAttribute, folder.Path + "/" + name);
                    sf.SetAttribute(DotaObjectsSchema.FolderType.InGCFAttribute, true);

                    DomNode par = folder.As<DomNode>();
                    par.GetChildList(DotaObjectsSchema.FolderType.FilesChild).Add(sf);


                    ProjectFolder subFolder = sf.As<ProjectFolder>();

                    RecursiveBuildFromVPK(ref subFolder, subItem);
                }
                if (HLLib.hlItemGetType(subItem) == HLLib.HLDirectoryItemType.HL_ITEM_FILE)
                {
                    string ext = name.Substring(name.LastIndexOf('.'));

                    ProjectFile f;
                    if (ProjectLoader.FileTypes.ContainsKey(ext))
                    {
                        ProjectLoader.FileTypeResolver resolver = ProjectLoader.FileTypes[ext];
                        f = (ProjectFile)(new DomNode(resolver.DomNodeType)).As(resolver.WrapperType);
                    }
                    else
                    {
                        f = (new DomNode(DotaObjectsSchema.FileType.Type)).As<ProjectFile>();
                    }

                    f.Name = name;
                    f.Path = folder.Path + "/" + name;
                    f.InGCF = true;

                    folder.Files.Add(f);

                }

            }

        }
        #endregion

    }
}
