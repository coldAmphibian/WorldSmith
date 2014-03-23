using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sce.Atf.Dom;


namespace WorldsmithATF.Project
{
    public class ProjectFile : DomNodeAdapter
    {
        public ProjectFile()
        {
            
        }

        public string Path
        {
            get { return GetAttribute<string>(DotaObjectsSchema.FileType.PathAttribute); }
            set { SetAttribute(DotaObjectsSchema.FileType.PathAttribute, value); }
        }

        public string Name
        {
            get { return GetAttribute<string>(DotaObjectsSchema.FileType.NameAttribute); }
            set { SetAttribute(DotaObjectsSchema.FileType.NameAttribute, value); }
        }

        public bool InGCF
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.FileType.InGCFAttribute); }
            set { SetAttribute(DotaObjectsSchema.FileType.InGCFAttribute, value); }
        }

    }
}
