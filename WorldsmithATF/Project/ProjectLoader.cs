using Sce.Atf.Dom;
using Sce.Atf.Adaptation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sce.Atf;

namespace WorldsmithATF.Project
{
    public static class ProjectLoader
    {

        public class FileTypeResolver
        {
            public DomNodeType DomNodeType
            {
                get;
                set;
            }

            public string DisplayName
            {
                get;
                set;
            }

            public Type WrapperType
            {
                get;
                set;
            }

            public string DisplayImageKey
            {
                get;
                set;
            }

        }

        public static Dictionary<string, FileTypeResolver> FileTypes = new Dictionary<string, FileTypeResolver>()
        {
            { ".txt", new FileTypeResolver() {
                DomNodeType = DotaObjectsSchema.KVDocumentType.Type,
                DisplayName = "Keyvalue Document",
                WrapperType = typeof(KVFile),
                DisplayImageKey = Resources.DocumentImage,
            }},
            { ".lua", new FileTypeResolver() {
                DomNodeType = DotaObjectsSchema.TextFileType.Type,
                DisplayName = "Lua Scriptfile",
                WrapperType = typeof(TextFile),
                DisplayImageKey = Resources.DocumentImage,
            }},

        };


        public static void BuildProjectFromDirectoriesRecursive(string path, ref ProjectFolder project)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                ProjectFolder folder = (new DomNode(DotaObjectsSchema.FolderType.Type)).As<ProjectFolder>();
                folder.Path = directory;
                folder.Name = directory.Substring(directory.LastIndexOf(Path.DirectorySeparatorChar) + 1);


                project.Files.Add(folder);
                BuildProjectFromDirectoriesRecursive(directory, ref folder);
            }

            foreach (string File in Directory.GetFiles(path))
            {

                string ext = Path.GetExtension(File);
                 ProjectFile f;
                if(FileTypes.ContainsKey(ext))
                {
                    FileTypeResolver resolver = FileTypes[ext];
                    f = (ProjectFile)(new DomNode(resolver.DomNodeType)).As(resolver.WrapperType);   
                }
                else
                {
                    f = (new DomNode(DotaObjectsSchema.FileType.Type)).As<ProjectFile>();
                }

                string name = Path.GetFileName(File);
               
                f.Path = File;
                f.Name = name;


                project.Files.Add(f);

            }
            
        }





    }
}
