using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millerdcjr.Restful.Models
{
    public class Address
    {
        private Guid addressID;
        private Guid state;

        public Guid ID { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public Guid StateID { get; set; }
        public string PostalCode { get; set; }
        public Guid CountryID { get; set; }

        public Address()
        {
            this.Street = string.Empty ;
            this.Street2 = string.Empty;
            this.City = string.Empty;
            this.StateID = Guid.NewGuid();
            this.CountryID = Guid.NewGuid();
            this.PostalCode = string.Empty;
        }

        public Address(string street, string street2, string city, Guid state, Guid country, string postalCode)
        {
            this.Street = street;
            this.Street2 = street2;
            this.City = city;
            this.StateID = state;
            this.CountryID = country;
            this.PostalCode = postalCode;
        }

        public Address(Guid addressID, string street, string street2, string city, Guid state, Guid countryID, string postalCode)
        {
            // TODO: Complete member initialization
            this.addressID = addressID;
            this.Street = street;
            this.Street2 = street2;
            this.City = city;
            this.state = state;
            this.CountryID = countryID;
            this.PostalCode = postalCode;
        }
    }
}