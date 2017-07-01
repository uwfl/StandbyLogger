using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.Models
{
    public class Company
    {
        [XmlAttribute]
        public string Name { get; set; }

        public Company()
        { }

        public Company(string name)
        {
            Name = name;
        }
    }
}
