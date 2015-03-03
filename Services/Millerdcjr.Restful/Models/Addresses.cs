using Millerdcjr.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millerdcjr.Restful.Models
{
    public class Addresses : List<Address>
    {
        public Addresses()
        {
        }

        public Addresses(AddressBO address)
        {
            this.Add(new Address
            {
                City = address.City,
                CountryID = address.CountryID,
                ID = address.ID,
                StateID = address.State,
                Street = address.Street,
                Street2 = address.Street2
            });
        }

        public Addresses(Address address)
        {
            if (address != null)
            {
                this.Add(address);
            }
        }

        public Addresses(AddressBOList list)
        {
            if (list != null && list.Count > 0)
            {
                this.AddRange(from l in list
                              select new Address
            {
                City = l.City,
                CountryID = l.CountryID,
                ID = l.ID,
                StateID = l.State,
                Street = l.Street,
                Street2 = l.Street2
            });
            }
        }
    }
}