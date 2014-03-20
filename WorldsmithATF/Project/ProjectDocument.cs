using Sce.Atf;
using Sce.Atf.Dom;
using Sce.Atf.Adaptation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.Project
{
    class ProjectDocument : DomDocument
    {
        /// <summary>
        /// Gets the document client's file type name</summary>
        public override string Type
        {
            get { return Localizer.Localize("Project"); }
        }

        /// <summary>
        /// Gets or sets whether the document is dirty (does it differ from its file)</summary>
        public override bool Dirty
        {
            get
            {
                ProjectEditingContext editingContext = DomNode.Cast<ProjectEditingContext>();
                return editingContext.History.Dirty;
            }
            set
            {
                ProjectEditingContext editingContext = DomNode.Cast<ProjectEditingContext>();
                editingContext.History.Dirty = value;
            }
        }

    }
}
