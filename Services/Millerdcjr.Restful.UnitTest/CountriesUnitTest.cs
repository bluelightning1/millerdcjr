using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Enums;
using Millerdcjr.Restful.Models;
using System.Linq;
using System.Collections.Generic;
using Millerdcjr.DAL;

namespace Millerdcjr.Restful.UnitTest
{
    [TestClass]
    public class CountriesUnitTest
    {
        [TestMethod]
        public void GetCountriesTestMethod()
        {
            AssignmentService service = new AssignmentService();
            Response<Models.Countries> countries = service.GetCountries("na1");
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Result.Count > 0);
            Assert.IsTrue(countries.ResponseType == EResponseType.Read);
        }

        [TestMethod]
        public void PostCountriesTestMethod()
        {
            Country country = new Country("United States", "US", "USA");
            AssignmentService service = new AssignmentService();
            Response<Models.Countries> countries = service.PostCountries(country);
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Result.Count > 0);
            Assert.IsTrue(countries.ResponseType == EResponseType.Created);
            var ids = countries.Result.Select(x => x.ID);
            Response<Models.Countries> dcountries = null;

            foreach (var id in ids)
            {
                dcountries = service.DeleteCountries(id);
            }
        }

        [TestMethod]
        public void DeleteCountriesTestMethod()
        {
            Country country = new Country("United States", "US", "USA");
            AssignmentService service = new AssignmentService();
            Response<Models.Countries> countries = service.PostCountries(country);
            var ids = countries.Result.Select(x => x.ID);
            List<Response<Models.Countries>> dcountries = new List<Response<Countries>>();
            
            foreach (var id in ids)
            {
                dcountries.Add(service.DeleteCountries(id));
            }

            Assert.IsNotNull(dcountries);
            Assert.IsTrue(dcountries.Count > 0);
        }

        [TestMethod]
        public void  CountriesTestMethod()
        {
            Country country = new Country(Guid.NewGuid(),"United States", "US", "USA");

            Assert.IsNotNull(country);
            Assert.AreEqual(country.ISOCode2, "US");
            Assert.AreEqual(country.Name, "United States");
            Assert.AreEqual(country.ISOCode3, "USA");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CountriesNullTestMethod()
        {
            CountryBO cbo = new CountryBO();
            Countries countries = new Countries(cbo);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CountriesNullListTestMethod()
        {
            CountryBOList cbo = new CountryBOList();
            Countries countries = new Countries(cbo);
        }
    }
}
