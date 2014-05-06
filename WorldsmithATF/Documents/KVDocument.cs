using KVLib;
using Sce.Atf;
using Sce.Atf.Dom;
using Sce.Atf.Applications;
using Sce.Atf.Controls.PropertyEditing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldsmithATF.Project;
using System.Windows.Forms;

using PropertyGrid = Sce.Atf.Controls.PropertyEditing.PropertyGrid;
using Sce.Atf.Controls;
using WorldsmithATF.UI;

namespace WorldsmithATF.Documents
{
    class KVDocument : IDocument
    {
        public ControlInfo ControlInfo
        {
            get;
            set;
        }

        public TreeListView DisplayControl
        {
            get;
            set;
        }

        public KeyValueTreeView KVTreeView
        {
            get;
            set;
        }


        public KVDocument(Uri file)
        {        
            string path = file.GetComponents(UriComponents.Path, UriFormat.Unescaped);

            bool inVPK = file.GetComponents(UriComponents.Scheme, UriFormat.Unescaped) == "vpk";

           
            Uri = new Uri(path);

            IsReadOnly = inVPK;

            LoadKeyValuesFromFile(path, inVPK);

            string filename = Path.GetFileName(path);

            ControlInfo = new ControlInfo(filename, "KeyValue: " + path, StandardControlGroup.Center);
            ControlInfo.IsDocument = true;


            TreeListView tlv = new TreeListView(TreeListView.Style.TreeList);
            
            TreeListViewAdapter adapter = new TreeListViewAdapter(tlv);
            
            var kvtv = new KeyValueTreeView();
            kvtv.AddRoot(KeyValueNode);
            adapter.View = kvtv;
            tlv.Columns.First().Width = 300;
            tlv.Columns.ElementAt(1).Width = 300;
            tlv.ExpandAll();

            KVTreeView = kvtv;
            DisplayControl = tlv;
           
            
        }

       

        void KeyValueNode_ItemChanged(object sender, EventArgs e)
        {
            Dirty = true;
        }

        private void LoadKeyValuesFromFile(string path, bool InVpk)
        {
         
            string text = "";

            if (InVpk)
            {
                text = DotaVPKService.Instance.ReadTextFromVPK(path);
            }
            else
            {
                text = File.ReadAllText(path);
            }

            KeyValue kv = KVParser.ParseKeyValueText(text);

            KeyValueNode = kv;

        }

        public KeyValue KeyValueNode
        {
            get;
            private set;
        }

        bool dirty = false;
        public bool Dirty
        {
            get { return dirty; }
            set
            {
                bool dirtyChanged = false;
                if (dirty != value) dirtyChanged = true;
                dirty = value;

                if (dirtyChanged) DirtyChanged.Raise(this, EventArgs.Empty);                
            }
        }

        public event EventHandler DirtyChanged;

        public bool IsReadOnly
        {
            get;
            private set;
        }

        public string Type
        {
            get { return "Key Value".Localize(); }
        }

        private Uri uri;
        public Uri Uri
        {
            get { return uri; }
            set
            {
                bool uriChanged = false;
                Uri oldUri = null;
                if (uri != value) 
                {
                    uriChanged = true;
                    oldUri = uri;
                }

                uri = value;

                if (uriChanged) UriChanged.Raise(this, new UriChangedEventArgs(oldUri));
            }
        }

        public event EventHandler<UriChangedEventArgs> UriChanged;


        public void Save()
        {

        }
    }
}
