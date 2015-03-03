using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using System.Xml.Serialization;

namespace Generic‎.Common‎
{
    public static class Serializer
    {
        public static bool XmlSerializeToFile<T>(string fullPathAndFileName, object content)
        {
            bool rv = false;
            if (Utilities.CreatDirectory(fullPathAndFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(fullPathAndFileName))
                {
                    Thread.Sleep(300);
                    serializer.Serialize(writer, content);
                    rv = true;
                }
                serializer = null;
            }
            else { rv = false; }
            return rv;
        }

        public static string XmlSerializeToString<T>(object content)
        {
            string rv = string.Empty;

            XmlSerializer serializer = new XmlSerializer(content.GetType());

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, content);

                rv = writer.ToString();
            }
            return rv;
        }

        public static T XmlDeserializeFromString<T>(string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        public static object XmlDeserializeFromString(string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
