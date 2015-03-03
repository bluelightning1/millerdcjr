using Generic‎.Common‎.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace Generic‎.Common‎.Interfaces
{
    public interface IService<T>
    {
        void SendRequest(T request, EMessageTypes typeMessage, bool isAsync, EReturnFacility returnFacility);
        void SendRequest(T request, EMessageTypes typeMessage, bool isAsync, EReturnFacility returnFacility, string facilityID= null);
    }
}
