using Generic.Common.Enums;
using Generic.Common.Exceptions;
using Generic.Common.Extenders;
using Millerdcjr.DAL;
using Millerdcjr.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Millerdcjr.Restful.Models
{
    public class Countries : List<Country>
    {
        public Countries()
        {

        }
        public Countries(CountryBOList list)
        {
            Load(list);
        }

        public Countries(CountryBO country)
        {
            if (country == null || string.IsNullOrEmpty(country.Name))
                throw new NullReferenceException("The country must be initialized or have a name.");
            // TODO: Complete member initialization
            this.Add(new Country
            {
                ID = country.ID,
                ISOCode2 = country.ISOCode2,
                ISOCode3 = country.ISOCode3,
                Name = country.Name
            });
        }

        public Countries(Country orig)
        {
            // TODO: Complete member initialization
            this.Add(orig);
        }

        private void Load(CountryBOList list)
        {
            try
            {
                if (list == null || list.Count() < 0)
                    throw new NullReferenceException("The List of countries must be initialized or have a count greater than or equal to zero.");
                // TODO: Complete member initialization
                this.AddRange((from c in list
                               select new Country
                               {
                                   ID = c.ID,
                                   Name = c.Name,
                                   ISOCode3 = c.ISOCode3,
                                   ISOCode2 = c.ISOCode2
                               }));
            }
            catch
            {
                throw;
            }
        }

        public void Read(string partialCountry, EWriteLocation location)
        {
            CountryBOList list = new CountryBOList();

            try
            {
                CountryBOCriteria criteria = new CountryBOCriteria(ELookup.ByPartialName, partialCountry);
                criteria.WriteLocation = location;

                list.Read(criteria);

                Load(list);

                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                //provide some logging...
                LogHandler.Write(Assembly.GetCallingAssembly().FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, ex, location.GetDescription(), null, null);

                throw;
            }
        }
    }
}