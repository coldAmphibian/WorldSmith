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
        TextEditing.TextEditor textEditor;


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
                "Open Editor",
                "Open the file in an editor",
                this);

            commandService.RegisterCommand(TreeListCommandsEnum.OpenSource,
                null,
                null,
                "View Source",
                "Open the file in an text editor",
                this);

            commandService.RegisterCommand(TreeListCommandsEnum.Rename,
            null,
            null,
            "Rename",
            "Renames the file",
            this);

            commandService.RegisterCommand(TreeListCommandsEnum.Delete,
            null,
            null,
            "Delete",
            "Deletes the file",
            this);
        }


        public IEnumerable<object> GetCommands(object context, object target)
        {
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
            if (file == null) return false;
            switch(e)
            {
                //case TreeListCommandsEnum.OpenEditor: return true;
                case TreeListCommandsEnum.OpenSource: return text != null;
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
                case TreeListCommandsEnum.OpenSource: OpenSource(); break;
                case TreeListCommandsEnum.Delete: DeleteFile(); break;
                case TreeListCommandsEnum.Rename: RenameFile(); break;
            }          


        }

        private void OpenSource()
        {
            TextFile file = contextRegistry.ActiveContext.As<TextFile>();

            textEditor.OpenDocument(file);

        }

        private void DeleteFile()
        {

        }

        private void RenameFile()
        {

        }


        public void UpdateCommand(object commandTag, CommandState commandState)
        {
           
        }

       
    }

}
