using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class Employee : Person
    {
        public Company Employer { get; set; }

        public Employee()
        { }

        public Employee(string firstname, string lastname, DateTime birthdate, Company employer)
            : base(firstname, lastname, birthdate)
        {
            Employer = employer;
        }

        public Employee(string firstname, string middlename, string lastname, DateTime birthdate, Company employer)
            : base(firstname, middlename, lastname, birthdate)
        {
            Employer = employer;
        }
    }
}
