using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF
{
    public static class GlobalSettings
    {
        private static char[] removeatend = { System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar };
        private static string dotadir;
        public static string DotaDirectory
        {
            get {return dotadir;}
            set {
				// Strip off the path separator at the end if the user put it in with one
			    // This fixes other parts of the code behaving oddly, as many windows forms
			    // components don't properly handle doubled path separators
			    dotadir = value.TrimEnd(removeatend);;
            }
		}

        public static string CurrentProjectDirectory
        {
            get;
            set;
        }

    }
}
