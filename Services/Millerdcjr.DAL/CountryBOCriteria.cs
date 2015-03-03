using Generic.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.DAL
{
    public class CountryBOCriteria
    {
        private Guid countrieIDs;

        public ELookup LoadOption { get; private set; }
        public string PartialCountry { get; set; }
        public EWriteLocation WriteLocation { get; set; }

        public CountryBOCriteria(ELookup lookup)
        {
            // TODO: Complete member initialization
            this.PartialCountry = string.Empty;
            this.LoadOption = lookup;
        }

        public CountryBOCriteria(ELookup lookup, string partialCountry)
        {
            // TODO: Complete member initialization
            this.LoadOption = lookup;
            this.PartialCountry = partialCountry;
        }

        public CountryBOCriteria(Guid countrieIDs)
        {
            // TODO: Complete member initialization
            this.countrieIDs = countrieIDs;
        }
    }
}
