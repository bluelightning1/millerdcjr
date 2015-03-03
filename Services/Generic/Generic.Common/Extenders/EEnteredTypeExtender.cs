using Generic‎.Common‎.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Extenders
{
    public static class EEnteredTypeEnumExtender
    {
        public static string GetDatabaseCode(this EEnteredType type)
        {
            string rv = null;
            var attribute = type.GetAttribute();
            if (attribute != null)
            {
                rv = attribute.DatabaseCode;
            }
            attribute = null;
            return rv;
        }

        public static string GetVUIDCode(this EEnteredType type)
        {
            string rv = null;
            var attribute = type.GetAttribute();
            if (attribute != null)
            {
                rv = attribute.VUIDCode;
            }
            attribute = null;
            return rv;
        }

        public static string GetName(this EEnteredType type)
        {
            string rv = null;
            var attribute = type.GetAttribute();
            if (attribute != null)
            {
                rv = attribute.Name;
            }
            attribute = null;
            return rv;
        }

        public static string GetDescription(this EEnteredType type)
        {
            string rv = null;
            var attribute = type.GetAttribute();
            if (attribute != null)
            {
                rv = attribute.Description;
            }
            attribute = null;
            return rv;
        }

        private static EnteredTypeAttribute GetAttribute(this Enum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<EnteredTypeAttribute>();
            return attribute;
        }
    }
}
