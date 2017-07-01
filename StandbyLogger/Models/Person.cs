using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }

        public Person(string firstname, string middlename, string lastname, DateTime birthdate)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Birthdate = birthdate;
        }

        public Person(string firstname, string lastname, DateTime birthdate)
            : this(firstname, string.Empty, lastname, birthdate)
        { }
    }
}
