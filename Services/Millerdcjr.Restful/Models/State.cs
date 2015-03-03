using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.Restful.Models
{
    public class State
    {

        public Guid ID { get; set; }
        public Guid CountryID { get; set; }
        public string Name { get; set; }
        public string IsoCode2 { get; set; }

        public State()
        {
            this.ID = Guid.NewGuid();
            this.Name = string.Empty;
            this.IsoCode2 = string.Empty;
        }

        public State(Guid countryId, string name, string isoCode2)
        {
            // TODO: Complete member initialization
            this.CountryID = countryId;
            this.Name = name;
            this.IsoCode2 = isoCode2;
        }

        public State(Guid countryId, Guid stateId)
        {
            // TODO: Complete member initialization
            this.CountryID = countryId;
            this.ID = stateId;
        }
    }
}
