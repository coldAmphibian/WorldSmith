using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using Sce.Atf;
using Sce.Atf.Adaptation;
using Sce.Atf.Applications;

using WorldsmithATF.UI;
using System.Windows.Forms;
using System.IO;

using WorldsmithATF.Project;

using Project = WorldsmithATF.Project.AddonProject;
using Sce.Atf.Dom;
using KVLib;

namespace WorldsmithATF.Commands
{

    public enum KeyValueCommandsEnum
    {
        EditKey,
        EditValue,
        AddChild,
        RemoveChild,
    }

    [Export(typeof(IInitializable))]
    [Export(typeof(KeyValueCommands))]
    [Export(typeof(IContextMenuCommandProvider))]
    class KeyValueCommands : ICommandClient, IInitializable, IContextMenuCommandProvider
    {

        ICommandService commandService;

        [ImportingConstructor]
        public KeyValueCommands(ICommandService commandService)
        {
            this.commandService = commandService;
        }


        public void Initialize()
        {
            commandService.RegisterCommand(KeyValueCommandsEnum.EditKey,
                null,
                null,
                "Edit Key".Localize(),
                "Edits the key for this Key-Value".Localize(),
                this);

            commandService.RegisterCommand(KeyValueCommandsEnum.EditValue,
                null,
                null,
                "Edit Value".Localize(),
                "Edits the value of this Key-Value".Localize(),
                this);

            commandService.RegisterCommand(KeyValueCommandsEnum.AddChild,
                null,
                null,
                "Add Child".Localize(),
                "Adds a child from this KV".Localize(),
                this);

            commandService.RegisterCommand(KeyValueCommandsEnum.RemoveChild,
                null,
                null,
                "Delete KeyValue".Localize(),
                "Deletes this Key-Value".Localize(),
                this);
        }

        public IEnumerable<object> GetCommands(object context, object target)
        {
            KeyValue kv = target as KeyValue;
            if(kv != null)
            {
                return new object[] {
                    KeyValueCommandsEnum.EditKey,
                    KeyValueCommandsEnum.EditValue,
                    KeyValueCommandsEnum.AddChild,
                    KeyValueCommandsEnum.RemoveChild,
                };
            }
            return new object[] { };
        }

        public bool CanDoCommand(object commandTag)
        {
            return true;
        }

        public void DoCommand(object commandTag)
        {
            
        }

        public void UpdateCommand(object commandTag, CommandState commandState)
        {
            
        }



      
    }
}
