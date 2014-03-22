using Sce.Atf.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.ObjectTypes
{
    class DotaDataObject : DomNodeAdapter
    {

        public string ClassName
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaDataObjectType.ClassNameAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaDataObjectType.ClassNameAttribute, value); }           
        }

        public string BaseClass
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaDataObjectType.BaseClassAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaDataObjectType.BaseClassAttribute, value); }
        }

    }
}
