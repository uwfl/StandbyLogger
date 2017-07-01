using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.Models
{
    public class Informer
    {
        [XmlAttribute]
        public string Name { get; set; }

        public Informer()
        { }

        public Informer(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
