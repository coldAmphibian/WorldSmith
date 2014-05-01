using Sce.Atf.Applications;
using Sce.Atf.Controls.PropertyEditing;
using Sce.Atf;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.UI
{
    [Export(typeof(UnitPropertyEditor))]
    [Export(typeof(IInitializable))]
    class UnitPropertyEditor : PropertyEditor
    {
         [ImportingConstructor]
        public UnitPropertyEditor(ICommandService commandService, IControlHostService controlHostService, IContextRegistry contextRegistry) : 
             base(commandService, controlHostService, contextRegistry)
         {

         }

         public override void Initialize()
         {
             base.Initialize();
             
         }

         protected override void Configure(out PropertyGrid propertyGrid, out ControlInfo controlInfo)
         {
             propertyGrid = new PropertyGrid();
             controlInfo = new ControlInfo(
                 "Unit Property Editor".Localize(),
                 "Edits selected object properties".Localize(),
                 StandardControlGroup.Center, null,
                 "asdf".Localize());
         }

         

    }
}
