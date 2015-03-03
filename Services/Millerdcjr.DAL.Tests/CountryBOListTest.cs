using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Configuration;

namespace Millerdcjr.DAL.Tests
{
    [TestClass]
    public class CountryBOListTest
    {
        private string iso3 = "USA";
        private string iso2 = "US";
        private string name = "US";

        [TestMethod]
        public void CreateSimple()
        {
            CountryBOList list = new CountryBOList();
            CountryBO country = list.Create(name, iso2, iso3, ApplicationConfiguration.GetLogLocation());

            Assert.IsTrue(country.Name.Equals(name));
            Assert.IsTrue(country.ISOCode2.Equals(iso2));
            Assert.IsTrue(country.ISOCode3.Equals(iso3));

            list.Delete(country.ID, ApplicationConfiguration.GetLogLocation());
            list.Clear();
            list = null;
            country = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateWithNullReferenceException()
        {
            CountryBOList list = new CountryBOList();
            CountryBO country = list.Create(name, null, iso3, ApplicationConfiguration.GetLogLocation());

            Assert.IsTrue(country == null);

            list.Clear();
            list = null;

            country = null;
        }

        [TestMethod]
        public void UpdateSimple()
        {
            CountryBOList list = new CountryBOList();
            CountryBO country = list.Create(name, iso2, iso3, ApplicationConfiguration.GetLogLocation());
            CountryBOList ulist = new CountryBOList();

            CountryBO countryUpdate = ulist.Update(country.ID, "xyz1", "i1", "is1", ApplicationConfiguration.GetLogLocation());

            Assert.IsFalse(country.Name.Equals(countryUpdate.Name));
            Assert.IsFalse(country.ISOCode2.Equals(countryUpdate.ISOCode2));
            Assert.IsFalse(country.ISOCode3.Equals(countryUpdate.ISOCode3));

            list.Delete(country.ID, ApplicationConfiguration.GetLogLocation());

            list.Clear();
            list = null;

            country = null;
        }
    }
}
