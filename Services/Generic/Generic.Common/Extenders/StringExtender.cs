using Generic‎.Common‎.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Extenders
{
    public static class StringExtender
    {
        public static string ReplaceElementsWithDefault(this string str, string toBeReplaced)
        {
            str = str.Replace(string.Format("{0}>", toBeReplaced), "Message>");
            return str;
        }

        public static string ToMySqlDateString(this string datestring)
        {
            var rv = datestring;
            string[] format = { "yyyyMMdd" };
            DateTime date;

            if (DateTime.TryParseExact(datestring,
                                       format,
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out date))
            {
                DateTime dt = DateTime.Now;
                if (DateTime.TryParse(date.ToShortDateString(),
                     CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    rv = dt.ToString(ApplicationConfiguration.GetDefaultMySqlDateTimeFormat());
            }

            return rv;
        }

        public static string ToString(this List<string> something, string splitter)
        {
            var rv = string.Empty;
            rv = something.Select(i => i).Aggregate((i, j) => i + splitter + j);
            return rv;
        }

        public static string ToWhereClauseString(this List<string> something, string splitter, string tick)
        {
            var rv = string.Empty;
            if (something != null && something.Count() > 0)
            {
                rv = something.Where(i => !string.IsNullOrEmpty(i)).Aggregate((i, j) => string.Format("{0}{3}{2}{3}{1}", i, j, splitter, tick));
                rv = string.Format("{1}{0}{1}", rv, tick);
            }
            return rv;
        }
    }
}
