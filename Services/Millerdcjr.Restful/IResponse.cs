using Generic.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.Restful
{
    public interface IResponse<T>
    {
        T Original { get; set; }
        T Result { get; set; }
        EResponseType ResponseType { get; set; }
        string Message { get; set; }
        void Set(T original, T result, EResponseType responseType, string message);
    }
}
