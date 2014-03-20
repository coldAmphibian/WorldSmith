using Sce.Atf.Adaptation;
using Sce.Atf.Applications;
using Sce.Atf.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsmithATF.ObjectTypes;

namespace WorldsmithATF.Project
{
    class ProjectEditingContext : Sce.Atf.Dom.EditingContext, IInstancingContext, INamingContext
    {
        #region INamingContext Members
        public bool CanSetName(object item)
        {
            return Adapters.Is<DotaDataObject>(item);
        }

        public string GetName(object item)
        {
            DotaDataObject obj = Adapters.As<DotaDataObject>(item);
            if (obj != null) return obj.ClassName;
            return null;
        }

        public void SetName(object item, string name)
        {
            DotaDataObject obj = Adapters.As<DotaDataObject>(item);
            if (obj != null) obj.ClassName = name;
        }
        #endregion

        #region IInstancingContext Members
        public bool CanCopy()
        {
            return Adapters.Any<DotaDataObject>(Selection);
        }

        public bool CanDelete()
        {
            return Adapters.Any<DomNode>(Selection);
        }

        public bool CanInsert(object dataObject)
        {
            throw new NotImplementedException();
        }

        public object Copy()
        {
            IEnumerable<ProjectFile> objs = Selection.AsIEnumerable<ProjectFile>();
            IEnumerable<DomNode> rootNodes = DomNode.GetRoots(Adapters.AsIEnumerable<DomNode>(objs));

            List<object> copies = new List<object>(DomNode.Copy(rootNodes));
            return new DataObject(copies.ToArray());
        }

        public void Delete()
        {
            IEnumerable<DomNode> rootNodes = DomNode.GetRoots(Selection.AsIEnumerable<DomNode>());
            foreach (DomNode node in rootNodes)
                if (node.Parent != null)
                    node.RemoveFromParent();

            Selection.Clear();
        }

        public void Insert(object dataObject)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
