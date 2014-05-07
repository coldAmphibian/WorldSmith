using Sce.Atf;
using Sce.Atf.Applications;
using Sce.Atf.Adaptation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldsmithATF.Project;

namespace WorldsmithATF.Commands
{

    public enum TreeListCommandsEnum
    {
        OpenEditor,
        OpenSource,
        Rename,
        Delete,

    }

    [Export(typeof(IInitializable))]
    [Export(typeof(TreeListCommands))]
    [Export(typeof(IContextMenuCommandProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    class TreeListCommands : ICommandClient, IInitializable, IContextMenuCommandProvider
    {

        IContextRegistry contextRegistry;
        ICommandService commandService;

        [Import(AllowDefault=false)]
        TextEditing.TextEditor textEditor = null;

        [Import(AllowDefault=false)]
        UI.KeyValueEditor kvEditor = null;


        [ImportingConstructor]
        public TreeListCommands(ICommandService service, IContextRegistry context)
        {
            contextRegistry = context;
            commandService = service;
        }


        public void Initialize()
        {
            commandService.RegisterCommand(TreeListCommandsEnum.OpenEditor,
                null,
                null,
                "Open".Localize(),
                "Open the file in an editor".Localize(),
                this);

            commandService.RegisterCommand(TreeListCommandsEnum.OpenSource,
                null,
                null,
                "View Source".Localize(),
                "Open the file in an text editor".Localize(),
                this);

            commandService.RegisterCommand(TreeListCommandsEnum.Rename,
            null,
            null,
            "Rename".Localize(),
            "Renames the file".Localize(),
            this);

            commandService.RegisterCommand(TreeListCommandsEnum.Delete,
            null,
            null,
            "Delete".Localize(),
            "Deletes the file".Localize(),
            this);
        }


        public IEnumerable<object> GetCommands(object context, object target)
        {
            if (context == null) return new object[] { };
            return new object[] {
                TreeListCommandsEnum.OpenEditor,
                TreeListCommandsEnum.OpenSource,
                TreeListCommandsEnum.Rename,
                TreeListCommandsEnum.Delete,
            };
        }

        public bool CanDoCommand(object commandTag)
        {
            TreeListCommandsEnum e = (TreeListCommandsEnum)commandTag;

            TextFile text = contextRegistry.ActiveContext.As<TextFile>();
            ProjectFile file = contextRegistry.ActiveContext.As<ProjectFile>();

            //Show the View Source option if the file has an editor
            bool ShouldShowViewSource = false;
            ShouldShowViewSource |= contextRegistry.ActiveContext.As<KVFile>() != null; 
            
            if (file == null) return false;
            switch(e)
            {
                case TreeListCommandsEnum.OpenEditor: return contextRegistry.ActiveContext.As<ProjectFolder>() == null;
                case TreeListCommandsEnum.OpenSource: return ShouldShowViewSource;
                case TreeListCommandsEnum.Delete: return !file.InGCF;
                case TreeListCommandsEnum.Rename: return !file.InGCF;
                default: return false;
            }
        }

        public void DoCommand(object commandTag)
        {
            TreeListCommandsEnum e = (TreeListCommandsEnum)commandTag;
            switch(e)
            {
                case TreeListCommandsEnum.OpenEditor: OpenEditor(); break;
                case TreeListCommandsEnum.OpenSource: OpenSource(); break;
                case TreeListCommandsEnum.Delete: DeleteFile(); break;
                case TreeListCommandsEnum.Rename: RenameFile(); break;
            }          


        }

        private void OpenEditor()
        {
            KVFile kvFile = contextRegistry.ActiveContext.As<KVFile>();
            if(kvFile != null)
            {
                //Open the file in a Key-Value editor
                kvEditor.OpenKVDocument(kvFile);
                return;
            }

            TextFile textFile = contextRegistry.ActiveContext.As<TextFile>();
            if(textFile != null)
            {
                //Open the file in a Text Editor

                textEditor.OpenDocument(textFile);
            }

        }

        private void OpenSource()
        {
            TextFile file = contextRegistry.ActiveContext.As<TextFile>();

            textEditor.OpenDocument(file, true);

        }

        private void DeleteFile()
        {
            //TODO: Delete the file from the disk and remove it's entry from the project dom tree
        }

        private void RenameFile()
        {
            //TODO: Rename files in the tree view
        }


        public void UpdateCommand(object commandTag, CommandState commandState)
        {
           //This function intentionally left blank
        }

       
    }

}
