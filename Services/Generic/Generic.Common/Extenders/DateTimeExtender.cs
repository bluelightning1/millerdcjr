using Generic‎.Common‎.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Extenders
{
    public static class DateTimeExtender
    {
        private const string TIME = " 00:00:00";
        private const string DATEFORMATSHORT = "yyyy-MM-dd";

        public static string ToMySqlDateString(this DateTime date, string format)
        {
            var rv = string.Empty;
            DateTime dt;

            if (DateTime.TryParse(date.ToString(), out dt))
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                {
                    
                    var sv = dt.ToString(format);
                    if (DateTime.TryParse(sv, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        // do for valid date
                        if (sv.LastIndexOf(TIME) >= 0)
                        {
                            rv = sv;
                        }
                        else
                        {
                            rv = dt.ToString(DATEFORMATSHORT) + TIME;
                        }
                    }
                    else
                    {
                        // do for invalid date
                    } 
                }
            return rv;
        }
    }
}
