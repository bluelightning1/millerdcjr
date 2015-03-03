using Generic.Common.Enums;
using Generic.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using Generic.Common.Extenders;


namespace Generic.Common.Configuration
{
    public class ApplicationConfiguration
    {
        const string defaultConnection = "defaultConnection";

        public static string GetAppSettingsConnectionByKey(string keyName)
        {
            string rv = string.Empty;
            var str = string.Format("Class: {0}, Method: {1}", MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name);

            try
            {
                if (ConfigurationManager.AppSettings.HasKeys())
                {
                    var key = ConfigurationManager.AppSettings.AllKeys.Where(x => x != null &&
                        x.Equals(keyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    var value = ConfigurationManager.AppSettings[key];

                    rv = ConfigurationManager.ConnectionStrings[value].ConnectionString;

                    if (string.IsNullOrEmpty(rv))
                    {
                        throw new Exception(string.Format("Key {0} has an EMPTY value", keyName));
                    }
                    key = null;
                    value = null;
                }
                else { throw new Exception(string.Format("Missing the connection: {0}", keyName)); }
            }
            catch (Exception ex)
            {
                var e = new CustomException(str, ex);
                throw;
            }
            finally { }
            return rv;
        }

        public static string GetAppSettingsByKey(string keyName)
        {
            string rv = string.Empty;

            try
            {
                if (ConfigurationManager.AppSettings.HasKeys())
                {
                    var key = ConfigurationManager.AppSettings.AllKeys.Where(x => x != null &&
                        x.Equals(keyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    rv = ConfigurationManager.AppSettings[key];
                }
                else { throw new Exception(string.Format("Appsettings has no keys: {0}", keyName)); }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }

            return rv;
        }

        public static bool GetEnableLogging()
        {
            var rv = false;
            bool.TryParse(GetAppSettingsByKey("EnableLogging"), out rv);
            return rv;
        }

        public static EWriteLocation GetLogLocation()
        {
            EWriteLocation rv = EWriteLocation.Unknown;
            var ll = GetAppSettingsByKey("LogLocation");

            switch (ll)
            {
                case "Database":
                    rv = EWriteLocation.Database;
                    break;
                case "File":
                    rv = EWriteLocation.File;
                    break;
                case "EventViewer":
                    rv = EWriteLocation.EventViewer;
                    break;
            }

            return rv;
        }

        public static string GetDefaultConnection()
        {
            string rv = string.Empty;
            var str = string.Format("Class: {0}, Method: {1}", MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name);

            try
            {
                if (ConfigurationManager.AppSettings.HasKeys())
                {
                    var key = ConfigurationManager.AppSettings.AllKeys.Where(x => x != null &&
                        x.Equals(defaultConnection, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    var value = ConfigurationManager.AppSettings[key];

                    rv = ConfigurationManager.ConnectionStrings[value].ConnectionString;

                    if (string.IsNullOrEmpty(rv))
                    {
                        throw new Exception(string.Format("Key {0} has an EMPTY value", defaultConnection));
                    }
                    else
                    {
                    }
                    key = null;
                    value = null;
                }
                else { throw new Exception(string.Format("Missing the connection: {0}", defaultConnection)); }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
            return rv;
        }

        public static string GetSchemaDrivenConnection()
        {
            string rv = string.Empty;
            var str = string.Format("Class: {0}, Method: {1}", MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name);

            try
            {
                if (ConfigurationManager.AppSettings.HasKeys())
                {
                    var key = ConfigurationManager.AppSettings.AllKeys.Where(x => x != null &&
                        x.Equals("schemaDriven", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    var value = ConfigurationManager.AppSettings[key];

                    rv = ConfigurationManager.ConnectionStrings[value].ConnectionString;

                    if (string.IsNullOrEmpty(rv))
                    {
                        throw new Exception(string.Format("Key {0} has an EMPTY value", defaultConnection));
                    }
                    else
                    {
                    }
                    key = null;
                    value = null;
                }
                else { throw new Exception(string.Format("Missing the connection: {0}", defaultConnection)); }
            }
            catch (Exception ex)
            {
                var e = new CustomException(str, ex);
                throw;
            }
            finally { }
            return rv;
        }

        public static string GetLogPathAndFileName(string name)
        {
            var rv = string.Empty;
            rv = string.Format(@"{0}\{1}_{2}.{3}", GetEnableLoggingDirectory(), string.Format(GetEnableLoggingPartialFileNames(), name),
                DateTime.Now.ToFileTimeUtc(), GetEnableLoggingExtension());
            return rv;
        }

        public static string GetMessageLoggingResponsePathAndFileName(string name)
        {
            var rv = string.Empty;
            rv = string.Format(@"{0}\{1}_{2}.{3}", GetEnableLoggingDirectory(), string.Format(GetLoggingResponsePartialFileNames(), name),
                DateTime.Now.ToFileTimeUtc(), GetEnableLoggingExtension());
            return rv;
        }

        public static string GetMessageLoggingRequestPathAndFileName(string name)
        {
            var rv = string.Empty;
            rv = string.Format(@"{0}\{1}_{2}.{3}", GetEnableLoggingDirectory(), string.Format(GetLoggingRequestsPartialFileNames(), name)
                , DateTime.Now.ToFileTimeUtc(), GetEnableLoggingExtension());
            return rv;
        }

        public static string GetDefaultMySqlDateTimeFormat()
        {
            var rv = GetAppSettingsByKey("DefaultMySqlDateTimeFormat");
            return rv;
        }

        public static string GetEventLog()
        {
            var rv = GetAppSettingsByKey("EventLog");
            return rv;
        }

        public static string GetEventLogSource()
        {
            var rv = GetAppSettingsByKey("EventLogSource");
            return rv;
        }

        private static string GetLoggingRequestsPartialFileNames()
        {
            var rv = GetAppSettingsByKey("EnableLoggingRequestsPartialFileNames");
            return rv;
        }

        private static string GetLoggingResponsePartialFileNames()
        {
            var rv = GetAppSettingsByKey("EnableLoggingResponsePartialFileNames");
            return rv;
        }

        private static string GetEnableLoggingPartialFileNames()
        {
            var rv = GetAppSettingsByKey("EnableLoggingPartialFileNames");
            return rv;
        }

        private static string GetEnableLoggingDirectory()
        {
            var rv = GetAppSettingsByKey("EnableLoggingDirectory");
            return rv;
        }

        private static string GetEnableLoggingExtension()
        {
            var rv = GetAppSettingsByKey("EnableLoggingExtension");
            return rv;
        }

        public static string GetRequestURL(string name)
        {
            var rv = GetAppSettingsByKey(string.Format("RequestURL_{0}", name));
            return rv;
        }

        public static string GetRequestHeader()
        {
            var rv = GetAppSettingsByKey("Header");
            return rv;
        }

        public static string GetRequestContentType()
        {
            var rv = GetAppSettingsByKey("ContentType");
            return rv;
        }

        public static string GetRequestAccept()
        {
            var rv = GetAppSettingsByKey("Accept");
            return rv;
        }

        public static string GetRequestMethod()
        {
            var rv = GetAppSettingsByKey("Method");
            return rv;
        }

        //internal static string GetVendorFacility()
        //{
        //    var rv = GetAppSettingsByKey("VendorFacility");
        //    return rv;
        //}

        public static char[] GetDefaultSplitter()
        {
            var rv = GetAppSettingsByKey("Splitter");
            return rv.ToCharArray();
        }

        //public static int GetDurationBetweenIntervals()
        //{
        //    var rv = 0;
        //    int.TryParse(GetAppSettingsByKey("DurationBetweenIntervals"), out rv);
        //    return rv;
        //}

        public static string GetDateTimeFormat()
        {
            var rv = GetAppSettingsByKey("DateTimeFormat");
            return rv;
        }

        public static int GetReadWriteTimeout()
        {
            var rv = 0;
            int.TryParse(GetAppSettingsByKey("ReadWriteTimeout"), out rv);
            return rv;
        }

        public static int GetTimeout()
        {
            var rv = 0;
            int.TryParse(GetAppSettingsByKey("Timeout"), out rv);
            return rv;
        }

        public static int GetContinueTimeout()
        {
            var rv = 0;
            int.TryParse(GetAppSettingsByKey("ContinueTimeout"), out rv);
            return rv;
        }

        //public static string GetVendorFacilityNumber()
        //{
        //    var rv = GetAppSettingsByKey("VendorFacilityNumber");
        //    return rv;
        //}

        //public static string GetVendor()
        //{
        //    var rv = GetAppSettingsByKey("Vendor");
        //    return rv;
        //}

        //public static string GetVendorListenerDNS()
        //{
        //    var rv = GetAppSettingsByKey("VendorListenerDNS");
        //    return rv;
        //}

        //public static string GetVendorFacilityName()
        //{
        //    var rv = GetAppSettingsByKey("VendorFacilityName");
        //    return rv;
        //}

        //public static string GetProductId()
        //{
        //    var rv = GetAppSettingsByKey("ProductIdMSH11");
        //    return rv;
        //}

        //public static string GetFacilityNumber()
        //{
        //    var rv = GetAppSettingsByKey("FacilityNumber");
        //    return rv;
        //}

        //public static string GetApplicationName()
        //{
        //    var rv = GetAppSettingsByKey("ApplicationName");
        //    return rv;
        //}

        //public static string Get_DNS()
        //{
        //    var rv = GetAppSettingsByKey("_DNS");
        //    return rv;
        //}
    }
}
