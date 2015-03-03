using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Generic.Common.Extenders;
using Generic.Common.Enums;


namespace Generic‎.Common‎.Exceptions
{
    [Serializable]
    public class CustomException
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }

        public CustomException()
        {
            this.TimeStamp = DateTime.Now;
        }

        public CustomException(string Message)
            : this()
        {
            this.Message = Message;
        }

        public CustomException(string message, System.Exception ex)
            : this(message + " " + ex.Message)
        {
            this.Message = message + " " + ex.Message;
            this.StackTrace = ex.StackTrace;
            this.TimeStamp = DateTime.Now;
            this.Source = ex.Source;
        }

        public CustomException(System.Exception ex)
            : this(ex.Message)
        {
            this.StackTrace = ex.StackTrace;
            this.Message = ex.Message;
            this.TimeStamp = DateTime.Now;
            this.Source = ex.Source;
        }

        public override string ToString()
        {
            return this.Message + this.StackTrace;
        }

       
    }
}
