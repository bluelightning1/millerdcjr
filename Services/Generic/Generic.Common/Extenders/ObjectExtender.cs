using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Common.Extenders
{
    public static class ObjectExtender
    {
        public static Guid GetGuid(this object obj)
        {
            Guid rv = Guid.Empty;
            if (obj != null && !obj.ToString().Equals("-1"))
            {
                rv = new Guid(obj.ToString());
            }
            return rv;
        }
    }
}
