using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public Employee Employee { get; private set; }

        public string Firstname
        {
            get { return Employee.Firstname; }
            set { Employee.Firstname = value; NotifyPropertyChanged(); }
        }

        public string Middlename
        {
            get { return Employee.Middlename; }
            set { Employee.Middlename = value; NotifyPropertyChanged(); }
        }

        public string Lastname
        {
            get { return Employee.Lastname; }
            set { Employee.Lastname = value; NotifyPropertyChanged(); }
        }

        public DateTime Birthday
        {
            get { return Employee.Birthdate; }
            set { Employee.Birthdate = value; NotifyPropertyChanged(); }
        }

        public EmployeeViewModel(Employee employee)
        {
            this.Employee = employee;
        }

        public EmployeeViewModel(string firstname, string middlename, string lastname, Company company)
        {
            Employee = new Employee(firstname, middlename, lastname, company);
        }
    }
}
