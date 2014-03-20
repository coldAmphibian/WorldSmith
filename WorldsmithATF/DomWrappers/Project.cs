using Sce.Atf.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.Project
{
    class Project : DomNodeAdapter
    {
        public IEnumerable<ProjectFile> ProjectFiles
        {
            get { return GetChildList<ProjectFile>(DotaObjectsSchema.ProjectType.FilesChild); }
        }

        public string Name
        {
            get { return GetAttribute<string>(DotaObjectsSchema.ProjectType.NameAttribute); }
            set { SetAttribute(DotaObjectsSchema.ProjectType.NameAttribute, value); }
        }
    }
}
