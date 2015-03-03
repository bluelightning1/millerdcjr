using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎
{
    public static class Utilities
    {
        public static bool CreatDirectory(string pathAndFileName)
        {
            bool rv = false;
            DirectoryInfo info = new DirectoryInfo(pathAndFileName.Substring(0, pathAndFileName.LastIndexOf("\\")));
            if (!info.Exists)
            {
                info.Create();
                rv = true;
            }
            else
                rv = info.Exists;
            return rv;
        }

    }
}
