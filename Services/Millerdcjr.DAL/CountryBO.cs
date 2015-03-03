using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.DAL
{
    public class CountryBO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ISOCode2 { get; set; }
        public string ISOCode3 { get; set; }
    }
}
