using Generic.Common.Configuration;
using Generic‎.Common‎.Enums;
using Generic‎.Common‎.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;


namespace Generic‎.Common‎.Extenders
{
    public static class IDataReaderExtender
    {
        public static string GetString(this IDataReader dataReader, string name, string valueForNull)
        {
            string rv = valueForNull;
            object value = dataReader.GetValue(name);
            if (value != null && value != DBNull.Value)
            {
                rv = value.ToString();
            }
            value = null;
            return rv;
        }

        public static Guid GetGuid(this IDataReader dataReader, string value)
        {
            Guid rv = Guid.Empty;
            object obj = dataReader.GetValue(value);
            if (value != null && obj != DBNull.Value)
            {
                rv = new Guid(obj.ToString());
            }
            value = null;
            return rv;
        }

        //public static string BinaryToText(this IDataReader dataReader, string name, string valueForNull)
        //{
        //    string rv = valueForNull;
        //    byte[] value = dataReader.GetByteValue(name);
        //    if (value != null)
        //    {
        //        rv = Encoding.Default.GetString(value);
        //    }
        //    value = null;
        //    return rv;
        //}

        //public static int GetInt(this IDataReader dataReader, string name)
        //{
        //    int rv = 0;
        //    object value = dataReader.GetValue(name);
        //    if (value != null && value != DBNull.Value)
        //    {
        //        int x = 0;
        //        if (int.TryParse(value.ToString(), out x))
        //            rv = x;
        //    }
        //    value = null;
        //    return rv;
        //}

        //public static DateTime GetDateTime(this IDataReader dataReader, string name)
        //{
        //    DateTime rv = new DateTime();
        //    object value = dataReader.GetValue(name);
        //    if (value != null && value != DBNull.Value)
        //    {
        //        DateTime x = new DateTime();
        //        if (DateTime.TryParse(value.ToString(), out x))
        //            rv = x;
        //    }
        //    value = null;
        //    return rv;
        //}

        private static object GetValue(this IDataReader datareader, string name)
        {
            var str = string.Format("Class: {0}, Method: {1}", MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name);
            object rv = string.Empty;
            try
            {
                int ordinal = GetOrdinal(datareader, name);
                rv = datareader.GetValue(ordinal);
            }
            catch (Exception ex)
            {
                CustomException cex = new CustomException(str, ex);
                cex.Log(ApplicationConfiguration.GetEnableLogging(), EWriteLocation.EventViewer);
                cex = null;
                throw;
            }
            finally { }
            return rv;

        }

        //private static byte[] GetByteValue(this IDataReader datareader, string name)
        //{
        //    var str = string.Format("Class: {0}, Method: {1}", MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name);
        //    byte[] rv = null;
        //    try
        //    {
        //        int ordinal = GetOrdinal(datareader, name);
        //        rv = datareader.GetValue(ordinal) as byte[];
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomException cex = new CustomException(str, ex);
        //        cex.Log(ApplicationConfiguration.GetEnableLogging(), EWriteLocation.EventViewer);
        //        cex = null;
        //        throw;
        //    }
        //    finally { }
        //    return rv;

        //}

        private static int GetOrdinal(IDataReader dataReader, string columName)
        {
            return dataReader.GetOrdinal(columName);
        }

        //public static float GetFloat(this IDataReader dataReader, string name)
        //{
        //    float rv = -1;
        //    object value = dataReader.GetValue(name);
        //    if (value != null && value != DBNull.Value)
        //    {
        //        float f = 0;
        //        if (float.TryParse(value.ToString(), out f))
        //        {
        //            rv = f;
        //        }
        //        else
        //        {
        //            throw new Exception("GetFloat method throws an error because it is unable to convert the value into a float");
        //        }
        //    }
        //    value = null;
        //    return rv;
        //}
      
        //public static bool GetBool(this IDataReader dataReader, string name)
        //{
        //    bool rv = false;
        //    object value = dataReader.GetValue(name);
        //    if (value != null && value != DBNull.Value)
        //    {
        //        if (value.ToString().Equals("Y", StringComparison.OrdinalIgnoreCase))
        //        {
        //            rv = true;
        //        }
        //        else if (value.ToString().Equals("N", StringComparison.OrdinalIgnoreCase))
        //        {
        //            rv = false;
        //        }
        //        else
        //        {
        //            throw new Exception("GetBool method throws an error because it is unable to convert the value into a predefined boolean Expecting (Y or N)");
        //        }
        //    }
        //    value = null;
        //    return rv;
        //}

        //public static EEnteredType GetEnteredType(this IDataReader dataReader, string columnName)
        //{
        //    EEnteredType rv = EEnteredType.Uknown;
        //    var strValue = dataReader.GetString(columnName, null);
        //    if (string.IsNullOrEmpty(strValue))
        //    {
        //        if (strValue.Equals(EEnteredType.Device_Entered.GetDatabaseCode(), StringComparison.OrdinalIgnoreCase))
        //        {
        //            rv = EEnteredType.Device_Entered;
        //        }
        //        else if (strValue.Equals(EEnteredType.Self_Entered.GetDatabaseCode(), StringComparison.OrdinalIgnoreCase))
        //        {
        //            rv = EEnteredType.Self_Entered;
        //        }
        //    }
        //    return rv;
        //}
   
    }
}
