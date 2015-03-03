using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Generic‎.Common‎.Log;
using System.Diagnostics;
using Generic‎.Common‎.Configuration;
using Generic‎.Common‎.Exceptions;
using Generic‎.Common‎.Extenders;
using Generic.Common.Enums;

namespace Generic‎.Common‎.Extenders
{
    public static class CustomExceptionExtender
    {
        public static bool Log(this CustomException exception, bool loggingIsEnabled, string fullFilePathAndFileName)
        {
            bool rv = false;
            try
            {
                if (!loggingIsEnabled)
                    return rv;

                Common.Log.Log.Write(exception, fullFilePathAndFileName);
                rv = true;
            }
            catch
            {
                rv = false;
            }
            return rv;
        }

        public static bool Log(this CustomException exception, bool loggingIsEnabled, string fullFilePath, string fileName)
        {
            bool rv = false;
            try
            {
                if (!loggingIsEnabled)
                    return rv;

                Common.Log.Log.Write(exception, fullFilePath, fileName);
                rv = true;
            }
            catch
            {
                rv = false;
            }
            return rv;
        }

        public static bool Log(this CustomException exception, bool loggingIsEnabled, EWriteLocation logLocation)
        {
            bool rv = false;
            try
            {
                if (!loggingIsEnabled)
                    return rv;

                if (logLocation == EWriteLocation.EventViewer)
                {
                    EventLog log = new EventLog();
                    log.Log = ApplicationConfiguration.GetEventLog();
                    log.Source = ApplicationConfiguration.GetEventLogSource();

                    // Create a trace listener for the event log.
                    EventLogTraceListener myTraceListener = new EventLogTraceListener();
                    myTraceListener.EventLog = log;

                    // Add the event log trace listener to the collection.
                    Trace.Listeners.Add(myTraceListener);

                    // Write output to the event log.
                    Trace.WriteLine(Serializer.XmlSerializeToString<CustomException>(exception));
                    rv = true;
                }
                else if (logLocation == EWriteLocation.Database)
                {

                }
                else if (logLocation == EWriteLocation.File)
                {
                    rv = LogToFile(exception);
                }
                else
                {
                    rv = LogToFile(exception);
                }

            }
            catch
            {
                rv = false;
            }
            return rv;
        }

        private static bool LogToFile(CustomException exception)
        {
            bool rvx = false;

            try
            {
                var dir = ApplicationConfiguration.GetLogPathAndFileName(DateTime.Now.ToFileTimeUtc().ToString());
                Common.Log.Log.Write(exception, dir);
                rvx = true;
            }
            catch
            {
                rvx = false;
            }

            return rvx;
        }
    }
}
