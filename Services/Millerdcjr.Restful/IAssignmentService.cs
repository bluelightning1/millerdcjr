using Generic.Common.Enums;
using Millerdcjr.Restful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Millerdcjr.Restful
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAssignmentService
    {

        [OperationContract]
        [WebGet(UriTemplate = "Addresses/{partialStreet}"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<Addresses> GetAddresses(string partialStreet);

        [OperationContract]
        [WebInvoke(UriTemplate = "Addresses", Method = "Post"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<Addresses> PostAddresses(Address newAddress);

        [OperationContract]
        [WebInvoke(UriTemplate = "Addresses", Method = "Put"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<Addresses> PutAddresses(Address addressToUpdate);

        [OperationContract]
        [WebInvoke(UriTemplate = "Country/{countryId}/States/{stateId}/Addresses/{id}", Method = "Delete"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<Addresses> DeleteAddresses(string countryId, string stateId, string id);

        [OperationContract]
        [WebGet(UriTemplate = "Countries/{partialCountry}"
            , ResponseFormat = WebMessageFormat.Json)]
        string GetCountries(string partialCountry);

        [OperationContract]
        [WebInvoke(UriTemplate = "Countries", Method = "Post"
            , ResponseFormat = WebMessageFormat.Json
            )]
        Response<Countries> PostCountries(Country country);

        [OperationContract]
        [WebInvoke(UriTemplate = "Countries", Method = "Put"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<Countries> PutCountries(Country country);

        [OperationContract]
        [WebInvoke(UriTemplate = "Countries/{id}", Method = "Delete"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<Countries> DeleteCountries(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Country/{countryId}/States/{stateValue}/{lookup}"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<States> GetStates(string countryId, string stateValue, string lookup = "0");

        [OperationContract]
        [WebInvoke(UriTemplate = "Country/{countryId}/States", Method = "Post"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<States> PostStates(string countryId, State state);

        [OperationContract]
        [WebInvoke(UriTemplate = "Country/{countryId}/States", Method = "Put"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<States> PutStates(string countryId, State state);

        [OperationContract]
        [WebInvoke(UriTemplate = "Country/{countryId}/States/{stateId}", Method = "Delete"
            , ResponseFormat = WebMessageFormat.Json)]
        Response<States> DeleteStates(string countryId, string stateId);
    }
}
