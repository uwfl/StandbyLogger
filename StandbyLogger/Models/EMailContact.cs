using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.Models
{
    public class EMailContact
    {
        [XmlAttribute]
        public string Description { get; set; }
        [XmlAttribute]
        public string EMailAddress { get; set; }

        public EMailContact()
        { }

        public EMailContact(string description, string eMailAddress)
        {
            Description = description;
            EMailAddress = eMailAddress;
        }
    }
}
