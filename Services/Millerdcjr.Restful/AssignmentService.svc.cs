using Millerdcjr.Restful.Models;
using Generic.Common.Extenders;
using Millerdcjr.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Generic.Common.Enums;
using Generic.Common.Configuration;
using System.ComponentModel;
using System.Net;
using Newtonsoft.Json;

namespace Millerdcjr.Restful
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AssignmentService : IAssignmentService
    {
        /// <summary>
        /// object for the method is to read the addresses which contain part of the street
        /// </summary>
        /// <param name="partialStreet">part of the street address to look up</param>
        /// <returns>Returns a response with the resulting addresses</returns>
        public Response<Addresses> GetAddresses(string partialStreet)
        {
            //var remoteAddress = OperationContext.Current.Channel.RemoteAddress;
            //var remoteMessage = OperationContext.Current.RequestContext.RequestMessage;

            Response<Addresses> response = new Response<Addresses>();
            AddressBOList list = new AddressBOList();

            try
            {
                AddressBOCriteria criteria = new AddressBOCriteria(partialStreet);
                list.Read(criteria);

                if (list.Count > 0)
                {
                    response.Set(null, new Addresses(list), EResponseType.Read, "Found addresses.");
                }
                else if (list.Count <= 0)
                {
                    response.Set(null, new Addresses(list), EResponseType.Warning, "No addresses were found.");
                }

                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new Addresses(list), EResponseType.Error, ex.Message);
            }
          
            return response;
        }

        /// <summary>
        /// method used to create an address
        /// </summary>
        /// <param name="street">Street, address, or location where mail is delivered</param>
        /// <param name="street2"></param>
        /// <param name="city">City where mail is delivered</param>
        /// <param name="state">State where mail is delivered</param>
        /// <param name="country">Country where mail is delivered</param>
        /// <param name="postalCode">Postal or Zip code where mail is delivered</param>
        /// <returns></returns>
        public Response<Addresses> PostAddresses(Address newAddress)
        {
            Response<Addresses> response = new Response<Addresses>();
            AddressBOList list = new AddressBOList();

            try
            {
                Addresses oaddr = new Addresses(newAddress);

                AddressBO addr = new AddressBO(newAddress.Street, newAddress.Street2, newAddress.City,
                    newAddress.StateID, newAddress.CountryID, newAddress.PostalCode);
                AddressBO address = list.Create(addr);
                Addresses addresses = new Addresses(address);
                if (address != null)
                {
                    if (address.City.Equals(newAddress.City, StringComparison.OrdinalIgnoreCase)
                        && address.PostalCode.Equals(newAddress.PostalCode, StringComparison.OrdinalIgnoreCase)
                        && address.State == newAddress.StateID
                        && address.CountryID == newAddress.CountryID
                        && address.Street.Equals(newAddress.Street, StringComparison.OrdinalIgnoreCase)
                        && address.Street2.Equals(newAddress.Street2, StringComparison.OrdinalIgnoreCase)
                        && address.ID != Guid.NewGuid())
                    {
                        response.Set(oaddr, addresses, EResponseType.Created, "Created address.");
                    }
                    else
                    {
                        response.Set(oaddr, addresses, EResponseType.Error, "Unable to create address successfully.");
                    }
                }
                else
                {
                    response.Set(null, addresses, EResponseType.Error, "Unable to create address.");
                }

                oaddr.Clear();
                oaddr = null;
                addr = null;
                address = null;
                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new Addresses(list), EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method used to provide updates to an existing address.
        /// </summary>
        /// <param name="addressID">Id of the address the user selected</param>
        /// <param name="street">street where mail is delivered</param>
        /// <param name="street2">street2 where mail is delivered</param>
        /// <param name="city">City where mail is delivered</param>
        /// <param name="state">State where mail is delivered</param>
        /// <param name="country">Country where mail is delivered</param>
        /// <param name="postalCode">Postal or Zip code where mail is delivered</param>
        /// <returns></returns>
        public Response<Addresses> PutAddresses(Address addressToUpdate)
        {
            Response<Addresses> response = new Response<Addresses>();
            AddressBOList list = new AddressBOList();

            try
            {
                Addresses oaddresses = new Addresses(addressToUpdate);
                AddressBO address = new AddressBO(addressToUpdate.ID, addressToUpdate.Street, addressToUpdate.Street2,
                    addressToUpdate.City, addressToUpdate.StateID, addressToUpdate.CountryID, addressToUpdate.PostalCode);
                AddressBO rv = list.Update(address);
                Addresses addresses = new Addresses(rv);

                if (address != null)
                {
                    if (address.City.Equals(addressToUpdate.City, StringComparison.OrdinalIgnoreCase)
                        && address.PostalCode.Equals(addressToUpdate.PostalCode, StringComparison.OrdinalIgnoreCase)
                        && address.State == addressToUpdate.StateID
                        && address.CountryID == addressToUpdate.CountryID
                        && address.Street.Equals(addressToUpdate.Street, StringComparison.OrdinalIgnoreCase)
                        && address.Street2.Equals(addressToUpdate.Street2, StringComparison.OrdinalIgnoreCase)
                        && address.ID == addressToUpdate.ID)
                    {
                        response.Set(oaddresses, addresses, EResponseType.Created, "Updated address.");
                    }
                    else
                    {
                        response.Set(oaddresses, addresses, EResponseType.Error, "Unable to Update address successfully.");
                    }
                }
                else
                {
                    response.Set(null, addresses, EResponseType.Error, "Unable to Update address.");
                }

                oaddresses.Clear();
                oaddresses = null;
                address = null;
                list.Clear();
                list = null;
                rv = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new Addresses(list), EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method used to delete an address.
        /// </summary>
        /// <param name="addressID">Id of the address the user selected</param>
        /// <returns></returns>
        public Response<Addresses> DeleteAddresses(string countryID, string stateID, string addressID)
        {
            Response<Addresses> response = new Response<Addresses>();
            AddressBOList list = new AddressBOList();

            try
            {
                Guid addr = new Guid(addressID);
                AddressBOCriteria criteria = new AddressBOCriteria(addr);
                AddressBO address = list.Delete(criteria);
                Addresses addresses = new Addresses(address);

                if (address != null)
                {

                    if (address.ID == addr)
                    {
                        response.Set(null, addresses, EResponseType.Created, "Deleted address.");
                    }
                    else
                    {
                        response.Set(null, addresses, EResponseType.Error, "Unable to Delete address successfully.");
                    }
                }
                else
                {
                    response.Set(null, addresses, EResponseType.Error, "Unable to Delete address.");
                }

                address = null;
                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new Addresses(list), EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method to read a list of countries availabe to the system
        /// </summary>
        /// <param name="partialCountry">partial name of the country</param>
        /// <returns></returns>
        public string GetCountries(string partialCountry)
        {
            string rv = string.Empty;

            //Response<string> response = new Response<string>();
            Countries c = new Countries();
            var logLocation = ApplicationConfiguration.GetLogLocation();
            try
            {
                c.Read(partialCountry, logLocation);
                if (c.Count > 0)
                {

                    rv = JsonConvert.SerializeObject(c);
                    //response.Set(null, JsonConvert.SerializeObject(c), EResponseType.Read, "Found Countries.");
                }
                else if (c.Count <= 0)
                {
                    rv = JsonConvert.SerializeObject(c);
                    //response.Set(null, JsonConvert.SerializeObject(c), EResponseType.Warning, "No Countries were found.");
                }
            }
            catch (Exception ex)
            {

                rv = JsonConvert.SerializeObject(c);
                //response.Set(null, JsonConvert.SerializeObject(c), EResponseType.Error, ex.Message);
            }

            return rv;
        }

        /// <summary>
        /// method to create a new country.
        /// NOTE: all three parameters are required
        /// </summary>
        /// <param name="name">name of the country to add, i.e. United Stats</param>
        /// <param name="isoCode2">2 digit code for the country, i.e. US</param>
        /// <param name="isoCode3">3 digit code for the country, i.e. USA</param>
        /// <returns></returns>
        public Response<Countries> PostCountries(Country newCountry)
        {
            Response<Countries> response = new Response<Countries>();
            CountryBOList list = new CountryBOList();

            try
            {
                Countries ocountry = new Countries(newCountry);
                if (string.IsNullOrEmpty(newCountry.Name) || string.IsNullOrEmpty(newCountry.ISOCode2)
                    || string.IsNullOrEmpty(newCountry.ISOCode3))
                {
                    response.Set(ocountry, null, EResponseType.Error, "Unable to create country successfully, invalid parameters.");
                }
                else
                {
                    CountryBO country = list.Create(newCountry.Name, newCountry.ISOCode2,
                        newCountry.ISOCode3, ApplicationConfiguration.GetLogLocation());
                    Countries countries = new Countries(country);

                    if (country != null)
                    {
                        if (country.Name.Equals(newCountry.Name, StringComparison.OrdinalIgnoreCase)
                            && country.ISOCode2.Equals(newCountry.ISOCode2, StringComparison.OrdinalIgnoreCase)
                            && country.ISOCode3 == newCountry.ISOCode3
                            && country.ID != Guid.NewGuid())
                        {
                            response.Set(ocountry, countries, EResponseType.Created, "Created country.");
                        }
                        else
                        {
                            response.Set(ocountry, countries, EResponseType.Error, "Unable to create country successfully.");
                        }
                    }
                    else
                    {
                        response.Set(null, countries, EResponseType.Error, "Unable to create country.");
                    }

                    ocountry.Clear();
                    ocountry = null;
                    country = null;
                    list.Clear();
                    list = null;
                }
            }
            catch (Exception ex)
            {
                response.Set(null, new Countries(list), EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method used to provide updates to an existing country.
        /// </summary>
        /// <param name="countryID">Id of the address the user selected</param>
        /// <param name="name">street where mail is delivered</param>
        /// <param name="isoCode2">street2 where mail is delivered</param>
        /// <param name="isoCode3">City where mail is delivered</param>
        /// <returns></returns>
        public Response<Countries> PutCountries(Country countryToUpdate)
        {
            Response<Countries> response = new Response<Countries>();
            CountryBOList list = new CountryBOList();

            try
            {
                Countries ocountries = new Countries(countryToUpdate);

                CountryBO country = list.Update(countryToUpdate.ID, countryToUpdate.Name, countryToUpdate.ISOCode2, countryToUpdate.ISOCode3, ApplicationConfiguration.GetLogLocation());
                Countries countries = new Countries(country);

                if (country != null)
                {
                    if (country.Name.Equals(countryToUpdate.Name, StringComparison.OrdinalIgnoreCase)
                        && country.ISOCode3.Equals(countryToUpdate.ISOCode3, StringComparison.OrdinalIgnoreCase)
                        && country.ID == countryToUpdate.ID
                        && country.ISOCode2.Equals(countryToUpdate.ISOCode2, StringComparison.OrdinalIgnoreCase))
                    {
                        response.Set(ocountries, countries, EResponseType.Created, "Updated country.");
                    }
                    else
                    {
                        response.Set(ocountries, countries, EResponseType.Error, "Unable to Update country successfully.");
                    }
                }
                else
                {
                    response.Set(null, countries, EResponseType.Error, "Unable to Update country.");
                }

                ocountries.Clear();
                ocountries = null;
                country = null;
                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new Countries(list), EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method used to delete a country.
        /// </summary>
        /// <param name="countryID">Id of the country the user selected</param>
        /// <returns></returns>
        public Response<Countries> DeleteCountries(string countryID)
        {
            Response<Countries> response = new Response<Countries>();
            CountryBOList list = new CountryBOList();

            try
            {
                Guid countryguid = new Guid(countryID);
                CountryBOCriteria criteria = new CountryBOCriteria(countryguid);
                CountryBO country = list.Delete(countryguid, ApplicationConfiguration.GetLogLocation());
                Countries countries = new Countries(country);

                if (country != null)
                {

                    if (country.ID == countryguid)
                    {
                        response.Set(null, countries, EResponseType.Created, "Deleted address.");
                    }
                    else
                    {
                        response.Set(null, countries, EResponseType.Error, "Unable to Delete address successfully.");
                    }
                }
                else
                {
                    response.Set(null, countries, EResponseType.Error, "Unable to Delete address.");
                }

                country = null;
                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new Countries(list), EResponseType.Error, ex.Message);
            }

            return response;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="stateValue"></param>
        /// <param name="lookup">this is the index of either 0 or 1 for ByGuid or ByPartialName respectively</param>
        /// <returns></returns>
        public Response<States> GetStates(string countryId, string stateValue, string lookup)
        {
            Response<States> rv = null;
            int look = 0;
            if (string.IsNullOrEmpty(lookup))
            {
                look = 0;
            }
            else
            {
                int.TryParse(lookup, out look);
            }

            ELookup up = (ELookup)look;

            switch (up)
            {
                case ELookup.ByGuid:
                    {
                        Guid stateId = new Guid(stateValue);
                        rv = GetStates(countryId, stateId);
                        break;
                    }
                case ELookup.ByPartialName:
                    {
                        rv = GetStates(countryId, stateValue);
                        break;
                    }
                default: {
                    rv = GetStates(countryId, stateValue);
                    break;
                }
            }
            return rv;
        }

        /// <summary>
        /// method to read a list of States availabe to the system
        /// </summary>
        /// <param name="partialState">partial name of the state</param>
        /// <returns></returns>
        private Response<States> GetStates(string countryId, string partialState)
        {

            Response<States> response = new Response<States>();
            States c = new States();
            var logLocation = ApplicationConfiguration.GetLogLocation();
            try
            {
                Guid countryguid = new Guid(countryId);

                StateBOCriteria crit = new StateBOCriteria(EOperation.Read, ELookup.ByPartialName, countryguid, partialState, logLocation.GetDescription());
                c.Read(crit);
                if (c.Count > 0)
                {
                    response.Set(null, c, EResponseType.Read, "Found States.");
                }
                else if (c.Count <= 0)
                {
                    response.Set(null, c, EResponseType.Warning, "No States were found.");
                }
            }
            catch (Exception ex)
            {

                response.Set(null, c, EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method to read a list of States availabe to the system
        /// </summary>
        /// <param name="partialState">partial name of the state</param>
        /// <returns></returns>
        private Response<States> GetStates(string countryId, Guid stateId)
        {
            Response<States> response = new Response<States>();
            States c = new States(); 
            var logLocation = ApplicationConfiguration.GetLogLocation();
            try
            {
                Guid countryguid = new Guid(countryId);
                StateBOCriteria crit = new StateBOCriteria(EOperation.Read, ELookup.ByGuid, countryguid, stateId, logLocation.GetDescription());
                c.Read(crit);
                if (c.Count > 0)
                {

                    response.Set(null, c, EResponseType.Read, null);
                }
                else if (c.Count <= 0)
                {
                    response.Set(null, c, EResponseType.Warning, "No States were found.");
                }
            }
            catch (Exception ex)
            {
            }

            return response;
        }

        /// <summary>
        /// method to create a new state.
        /// NOTE: all two parameters are required
        /// </summary>
        /// <param name="name">name of the state to add, i.e. Minnesota</param>
        /// <param name="isoCode2">2 digit code for the state, i.e. MN</param>
        /// <returns></returns>
        public Response<States> PostStates(string countryId, State newState)
        {
            Response<States> response = new Response<States>();
            StateBOList list = new StateBOList();

            try
            {
                States ostate = new States(newState);
                if (string.IsNullOrEmpty(newState.Name) || string.IsNullOrEmpty(newState.IsoCode2))
                {
                    response.Set(ostate, null, EResponseType.Error, "Unable to create state successfully, invalid parameters.");
                }
                else
                {
                    StateBO state = list.Create(newState.CountryID, newState.Name, newState.IsoCode2);
                    States states = new States(state);

                    if (state != null)
                    {
                        if (state.Name.Equals(newState.Name, StringComparison.OrdinalIgnoreCase)
                            && state.IsoCode2.Equals(newState.IsoCode2, StringComparison.OrdinalIgnoreCase)
                            && state.ID != Guid.NewGuid())
                        {
                            response.Set(ostate, states, EResponseType.Created, "Created state.");
                        }
                        else
                        {
                            response.Set(ostate, states, EResponseType.Error, "Unable to create state successfully.");
                        }
                    }
                    else
                    {
                        response.Set(null, states, EResponseType.Error, "Unable to create state.");
                    }

                    ostate.Clear();
                    ostate = null;
                    states = null;
                    list.Clear();
                    list = null;
                }
            }
            catch (Exception ex)
            {
                response.Set(null, new States(list), EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method used to provide updates to an existing State.
        /// </summary>
        /// <param name="id">Id of the address the user selected</param>
        /// <param name="name">name where mail is delivered</param>
        /// <param name="isoCode2">isoCode2 where mail is delivered</param>
        /// <returns></returns>
        public Response<States> PutStates(string countryId, State stateToUpdate)
        {
            Response<States> response = new Response<States>();
            StateBOList list = new StateBOList();

            try
            {
                States ostate = new States(stateToUpdate);
                StateBO statebo = list.Update(stateToUpdate.CountryID, stateToUpdate.ID, stateToUpdate.Name, stateToUpdate.IsoCode2);
                States states = new States(statebo);

                if (statebo != null)
                {
                    if (statebo.Name.Equals(stateToUpdate.Name, StringComparison.OrdinalIgnoreCase)
                        && statebo.ID == stateToUpdate.ID
                        && statebo.IsoCode2.Equals(stateToUpdate.IsoCode2, StringComparison.OrdinalIgnoreCase))
                    {
                        response.Set(ostate, states, EResponseType.Created, "Updated State.");
                    }
                    else
                    {
                        response.Set(ostate, states, EResponseType.Error, "Unable to Update State successfully.");
                    }
                }
                else
                {
                    response.Set(null, states, EResponseType.Error, "Unable to Update State.");
                }

                ostate.Clear();
                ostate = null;
                states = null;
                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new States(list), EResponseType.Error, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// method used to delete a state.
        /// </summary>
        /// <param name="id">Id of the state the user selected</param>
        /// <returns></returns>
        public Response<States> DeleteStates(string countryId, string stateid)
        {
            Response<States> response = new Response<States>();
            StateBOList list = new StateBOList();
            var logLocation = ApplicationConfiguration.GetLogLocation();
            try
            {
                States s = new States();
                Guid stateguid = new Guid(stateid);
                Guid countryguid = new Guid(countryId);

                StateBOCriteria cr = new StateBOCriteria(EOperation.Read, ELookup.ByGuid, countryguid, stateid, logLocation.GetDescription());
                s.Read(cr);

                if (s.Count > 0)
                {
                    var state = s.FirstOrDefault();
                    if (state != null)
                    {

                        StateBO stateBO = list.Delete(state.CountryID, state.ID, state.Name, state.IsoCode2);
                        States states = new States(stateBO);

                        if (stateBO != null)
                        {
                            if (stateBO.ID == stateguid)
                            {
                                response.Set(null, states, EResponseType.Created, "Deleted State.");
                            }
                            else
                            {
                                response.Set(null, states, EResponseType.Error, "Unable to Delete State successfully.");
                            }
                        }
                        else
                        {
                            response.Set(null, states, EResponseType.Error, "Unable to Delete State.");
                        }
                        stateBO = null;

                    }
                    else
                    {
                        response.Set(null, s, EResponseType.Error, "Unable to locate the State to be deleted.");
                    }
                    state = null;

                    list.Clear();
                    list = null;
                }
                else
                {
                    response.Set(null, s, EResponseType.Error, "Unable to find the State to be deleted.");

                }
                s.Clear();
                s = null;
            }
            catch (Exception ex)
            {
                response.Set(null, new States(list), EResponseType.Error, ex.Message);
            }

            return response;
        }
    }
}
