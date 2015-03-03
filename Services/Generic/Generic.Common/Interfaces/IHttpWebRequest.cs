using Generic‎.Common‎.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace Generic‎.Common‎.Interfaces
{
    public interface IHttpWebRequest
    {
        HttpWebRequest CreateSoapWebRequest(EReturnFacility returnFacility, string facilityID);
    }
}
