using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sce.Atf.Dom;


namespace WorldsmithATF.Project
{
    class ProjectFile : DomNodeAdapter
    {
        public string Path
        {
            get { return GetAttribute<string>(DotaObjectsSchema.FileType.PathAttribute); }
            set { SetAttribute(DotaObjectsSchema.FileType.PathAttribute, value); }
        }

    }
}
