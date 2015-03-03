using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;


namespace Generic‎.Common‎.Extenders
{
    public static class EnumExtender
    {
        // no Enum.GetValues() in Silverlight
        public static IEnumerable<T> GetEnumValues<T>(this Enum enm)
        {
            List<T> enumValue = new List<T>();

            Type enumType = typeof(T);
            var l = (from e in Enum.GetValues(enumType).Cast<object>().Select(o => o == null ? 0 : o)
                     select (T)e);
            return l;

        } // GetEnumValues

        // no Enum.GetValues() in Silverlight
        public static IEnumerable<string> GetEnumDescriptions<T>(this Enum enm)
        {
            Type enumType = typeof(T);
            var l = (from e in Enum.GetValues(enumType).Cast<object>().Select(o => o == null ? 0 : o)
                     select e.ToString()).ToList();

            return l;

        } 

        // GetEnumValue
        // no Enum.GetValues() in Silverlight
        public static T GetEnumValue<T>(this Enum enm, string valueToFind)
        {
            List<T> enumValue = new List<T>();

            Type enumType = typeof(T);
            var l = (from e in Enum.GetValues(enumType).Cast<object>().Select(o => o == null ? 0 : o)
                     where e.ToString().Equals(valueToFind, StringComparison.OrdinalIgnoreCase)
                     select (T)e).FirstOrDefault();

            return l;
        } 

        public static string GetDescription(this Enum value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetAttributeDescription(this Enum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<DescriptionAttribute>();

            return attribute == null ? String.Empty : attribute.Description;
        }
    }
}
