using Sce.Atf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.Documents
{
    class KVDocument : IDocument
    {


        public bool Dirty
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler DirtyChanged;

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public string Type
        {
            get { throw new NotImplementedException(); }
        }

        public Uri Uri
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<UriChangedEventArgs> UriChanged;
    }
}
