using System;
using System.Xml.Serialization;

namespace StandbyLogger.Models
{
    public class Person
    {
        [XmlAttribute]
        public string Firstname { get; set; }
        [XmlAttribute]
        public string Middlename { get; set; }
        [XmlAttribute]
        public string Lastname { get; set; }
        [XmlIgnore]
        public DateTime Birthdate { get; set; }
        [XmlIgnore]
        public string DisplayName
        {
            get
            {
                return Lastname + ", " + Firstname + " " + Middlename;
            }
        }

        protected Person()
        { }

        public Person(string firstname, string middlename, string lastname)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
        }

        public Person(string firstname, string lastname)
            : this(firstname, string.Empty, lastname)
        { }

        public Person(string firstname, string lastname, DateTime birthdate)
            : this(firstname, string.Empty, lastname, birthdate)
        { }

        public Person(string firstname, string middlename, string lastname, DateTime birthdate)
            : this(firstname, middlename, lastname)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Birthdate = birthdate;
        }

    }
}
