using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.Project
{
    class ProjectFolder : ProjectFile
    {
        public IList<ProjectFile> Files
        {
            get { return GetChildList<ProjectFile>(DotaObjectsSchema.FolderType.FilesChild); }
        }


    }
}
