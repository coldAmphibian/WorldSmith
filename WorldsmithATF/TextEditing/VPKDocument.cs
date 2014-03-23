using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Sce.Atf;
using Sce.Atf.Applications;
using Sce.Atf.Controls.SyntaxEditorControl;
using WorldsmithATF.Project;

namespace WorldsmithATF.TextEditing
{
    /// <summary>
    /// Adapts the CodeDocument to IDocument and synchronizes URI and dirty bit changes to the
    /// ControlInfo instance used to register the viewing control in the UI</summary>
    public class VPKDocument : IDocument
    {
        DotaVPKService vpkService;

        /// <summary>
        /// Constructor</summary>
        /// <param name="uri">URI of document</param>
        public VPKDocument(string uri, DotaVPKService vpkService)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            this.vpkService = vpkService;

            m_uri = uri;

            string filePath = uri;
            string fileName = Path.GetFileName(filePath);

            m_type = GetDocumentType(fileName);

            m_editor = TextEditorFactory.CreateSyntaxHighlightingEditor();

            Languages lang = GetDocumentLanguage(fileName);
            m_editor.SetLanguage(lang);
            Control ctrl = (Control)m_editor;
            ctrl.Tag = this;

            m_editor.EditorTextChanged += editor_EditorTextChanged;

            m_controlInfo = new ControlInfo(fileName, filePath, StandardControlGroup.Center);
            // tell ControlHostService this control should be considered a document in the menu, 
            // and using the full path of the document for menu text to avoid adding a number in the end 
            // in control header,  which is not desirable for documents that have the same name 
            // but located at different directories.
            m_controlInfo.IsDocument = true;
        }

        private void editor_EditorTextChanged(object sender, EditorTextChangedEventArgs e)
        {
            bool dirty = m_editor.Dirty;
            if (dirty != m_dirty)
            {
                Dirty = dirty;
            }
        }

        /// <summary>
        /// Gets main editor interface</summary>
        public ISyntaxEditorControl Editor
        {
            get { return m_editor; }
        }

        /// <summary>
        /// Gets editor Control</summary>
        public Control Control
        {
            get { return (Control)m_editor; }
        }

        /// <summary>
        /// Gets ControlInfo</summary>
        public ControlInfo ControlInfo
        {
            get { return m_controlInfo; }
            set { m_controlInfo = value; }
        }

        /// <summary>
        /// Reads document data from stream</summary>
        public void Read()
        {
            string filePath = m_uri;
            m_editor.Text = vpkService.ReadTextFromVPK(filePath);
            m_editor.Dirty = false;
            m_editor.ReadOnly = true;           
        }
        /// <summary>
        /// Writes document data to stream</summary>
        public void Write()
        {
           //Do Nothing
        }

        #region IDocument Members

        /// <summary>
        /// Gets whether the document is read-only</summary>
        public bool IsReadOnly
        {
            get { return true; } //Everything from the VPK is read-only since we cannot modify the VPK. 
        }

        /// <summary>
        /// Gets or sets whether the document is dirty (does it differ from its file)</summary>
        public bool Dirty
        {
            get
            {
                return m_dirty;
            }
            set
            {
                if (value != m_dirty)
                {
                    m_dirty = value;
                    if (value != m_editor.Dirty)
                        m_editor.Dirty = value;

                    UpdateControlInfo();

                    OnDirtyChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Event that is raised when the Dirty property changes</summary>
        public event EventHandler DirtyChanged;

        protected virtual void OnDirtyChanged(EventArgs e)
        {
            DirtyChanged.Raise(this, e);
        }

        #endregion

        #region IResource Members

        /// <summary>
        /// Gets a string identifying the type of the resource to the end-user</summary>
        public string Type
        {
            get { return m_type; }
        }
        private string m_type;

        /// <summary>
        /// Gets or sets the resource URI</summary>
        public Uri Uri
        {
            get { return new Uri("C:\\"); }
            set { }
            
        }
        private string m_uri;

        /// <summary>
        /// Event that is raised after the resource's URI changes</summary>
        public event EventHandler<UriChangedEventArgs> UriChanged;

        /// <summary>
        /// Raises the UriChanged event and performs custom processing</summary>
        /// <param name="e">UriChangedEventArgs containing event data</param>
        protected virtual void OnUriChanged(UriChangedEventArgs e)
        {
            UriChanged.Raise(this, e);
        }

        #endregion

        private void UpdateControlInfo()
        {
            string filePath = Uri.LocalPath;
            string fileName = Path.GetFileName(filePath);
            if (Dirty)
                fileName += "*";

            m_controlInfo.Name = fileName;
            m_controlInfo.Description = filePath;
        }

        /// <summary>
        /// Obtains document type, i.e., type of document text</summary>
        /// <param name="path">Document path</param>
        /// <returns>String indicating document type</returns>
        public static string GetDocumentType(string path)
        {
            string extension = Path.GetExtension(path).ToLower();
            switch (extension)
            {
                case ".txt":
                    return Localizer.Localize("Text");
                case ".lua":
                    return Localizer.Localize("Lua");
                default:
                    return Localizer.Localize("Text");
            }
        }

        /// <summary>
        /// Gets document language</summary>
        /// <param name="path">Document path</param>
        /// <returns>Document language type</returns>
        public static Languages GetDocumentLanguage(string path)
        {
            string extension = Path.GetExtension(path).ToLower();
            switch (extension)
            {
                case ".txt":
                    return Languages.Text;
                case ".lua":
                    return Languages.Lua;
                default:
                    return Languages.Text;
            }
        }

        private readonly ISyntaxEditorControl m_editor;
        private ControlInfo m_controlInfo;
        private bool m_dirty;
    }
}
