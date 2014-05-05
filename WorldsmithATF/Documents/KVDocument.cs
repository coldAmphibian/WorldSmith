using KVLib;
using Sce.Atf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldsmithATF.Project;

namespace WorldsmithATF.Documents
{
    class KVDocument : IDocument
    {

        public KVDocument(KVFile file)
        {
           
            string path = file.Path;

            if(file.InGCF)
            {
                path = "VPK:/" + path;
            }
            Uri = new Uri(path);

            IsReadOnly = file.InGCF;

            LoadKeyValuesFromFile(file);
        }

        private void LoadKeyValuesFromFile(KVFile file)
        {
            string path = file.Path;

            string text = "";

            if(file.InGCF)
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
    }
}
