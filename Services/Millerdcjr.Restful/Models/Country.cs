using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Millerdcjr.Restful.Models
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ISOCode2 { get; set; }
        [DataMember]
        public string ISOCode3 { get; set; }

        public Country()
        {

        }

        public Country(string name, string isoCode2, string isoCode3)
        {
            // TODO: Complete member initialization
            this.Name = name;
            this.ISOCode2 = isoCode2;
            this.ISOCode3 = isoCode3;
        }

        public Country(Guid id, string name, string isocode2, string isocode3)
        {
            this.ID = id;
            this.Name = name;
            this.ISOCode2 = isocode2;
            this.ISOCode3 = isocode3;
        }
    }
}