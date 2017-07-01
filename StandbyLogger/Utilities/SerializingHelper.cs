using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.Utilities
{
    public static class SerializingHelper
    {
        public static void Serialize(object objectToSerialize, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, objectToSerialize);
            }
        }

        public static T Deserialize<T>(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StreamReader(filename))
            {
                var deserialized = (T)serializer.Deserialize(reader);
                return deserialized;
            }
        }
    }
}
