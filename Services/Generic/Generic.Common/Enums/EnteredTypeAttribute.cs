using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Enums
{
    public class EnteredTypeAttribute : Attribute
    {
        public string VUIDCode { get; set; }
        public string DatabaseCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        
        public EnteredTypeAttribute()
        {
            this.VUIDCode = string.Empty;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.DatabaseCode = string.Empty;
        }

        public EnteredTypeAttribute(string vuidCode, string databaseCode, string name)
        {
            this.VUIDCode = vuidCode;
            this.Name = name;
            this.Description = string.Empty;
            this.DatabaseCode = databaseCode;
        }

        public EnteredTypeAttribute(string desc, string vuidCode, string databaseCode, string name)
        {
            this.VUIDCode = vuidCode;
            this.Name = name;
            this.Description = desc;
            this.DatabaseCode = databaseCode;
        }
    }
}
