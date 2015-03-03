using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.DAL
{
    public class AddressBOCriteria
    {
        private List<Guid> addressID;
        private Guid addressID1;

        public string PartialStreet {get; private set;}

        public AddressBOCriteria(string partialStreet)
        {
            // TODO: Complete member initialization
            this.PartialStreet = partialStreet;
        }

        public AddressBOCriteria(List<Guid> addressID)
        {
            // TODO: Complete member initialization
            this.addressID = addressID;
        }

        public AddressBOCriteria(Guid addressID1)
        {
            // TODO: Complete member initialization
            this.addressID1 = addressID1;
        }
    }
}
