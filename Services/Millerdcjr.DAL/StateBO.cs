using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.DAL
{
    public class StateBO
    {
        public Guid ID { get; set; }
        public Guid CountryID { get; set; }
        public string Name { get; set; }
        public string IsoCode2 { get; set; }

        public StateBO()
        {

        }
    }
}
