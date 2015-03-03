using Generic.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.DAL
{
    public class StateBOCriteria
    {
        public ELookup Lookup { get; private set; }
        public Guid StateId { get; private set; }
        public Guid CountryId { get; private set; }
        public string PartialState { get; private set; }
        public string LogLocation { get; private set; }
        public EOperation Operation { get; set; }

        public StateBOCriteria()
        {

        }

        public StateBOCriteria(EOperation operation, ELookup eLookup, Guid countryId, string partialName,string logLocation)
        {
            this.Lookup = eLookup;
            this.PartialState = partialName;
            this.LogLocation = logLocation;
            this.CountryId = countryId;
            this.Operation = operation;
        }

        public StateBOCriteria(EOperation operation, ELookup eLookup, Guid countryId, Guid stateId, string logLocation)
        {
            this.Lookup = eLookup;
            this.LogLocation = logLocation;
            this.CountryId = countryId;
            this.StateId = stateId;
            this.Operation = operation;
        }
    }
}
