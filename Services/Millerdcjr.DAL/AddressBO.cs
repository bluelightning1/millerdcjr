using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.DAL
{
    public class AddressBO
    {
        public AddressBO(Guid addressID)
        {
            this.ID = addressID;
        }

        public AddressBO(string street, string street2, string city, Guid state, Guid country, string postalCode)
        {
            // TODO: Complete member initialization
            this.Street = street;
            this.Street2 = street2;
            this.City = city;
            this.State = state;
            this.CountryID = country;
            this.PostalCode = postalCode;
        }

        public AddressBO(Guid id, string street, string street2, string city, Guid state, Guid country, string postalCode)
        {
            this.ID = id;
            this.Street = street;
            this.Street2 = street2;
            this.City = city;
            this.State = state;
            this.CountryID = country;
            this.PostalCode = postalCode;
        }

        public Guid ID { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public Guid State { get; set; }
        public  string PostalCode { get; set; }
        public Guid CountryID { get; set; }
    }
}
