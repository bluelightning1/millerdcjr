using Generic.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.Restful
{
    public abstract class ResponseBase<T> : IResponse<T>
    {
        public T Original { get; set; }
        public T Result { get; set; }
        public EResponseType ResponseType { get;  set; }
        public string Message { get;  set; }

        public ResponseBase()
        {
            this.ResponseType = EResponseType.Warning;
            this.Message = string.Empty;
            this.Result = default(T);
            this.Original = default(T);
        }

        public virtual void Set(T original, T result, EResponseType responseType, string message)
        {
            this.Original = original;
            this.Result = result;
            this.ResponseType = responseType;
            this.Message = message;
        }
    }
}
