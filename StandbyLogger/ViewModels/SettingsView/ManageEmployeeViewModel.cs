using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class ManageEmployeeViewModel : BaseViewModel
    {
        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; NotifyPropertyChanged(); }
        }

        private string _middlename;
        public string Middlename
        {
            get { return _middlename; }
            set { _middlename = value; NotifyPropertyChanged(); }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; NotifyPropertyChanged(); }
        }

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get { return _employees; }
            set { _employees = value; NotifyPropertyChanged(); }
        }

        private EmployeeViewModel _selectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged();

                if (value != null)
                {
                    Firstname = value.Firstname;
                    Middlename = value.Middlename;
                    Lastname = value.Lastname;
                }
            }
        }
        
        public RelayCommand AddEmployeeCommand { get; set; }
        public RelayCommand UpdateEmployeeCommand { get; set; }
        public RelayCommand RemoveEmployeeCommand { get; set; }

        public ManageEmployeeViewModel()
        {
            Employees = new ObservableCollection<EmployeeViewModel>();
            AddEmployeeCommand = new RelayCommand(c => AddEmployee(), c => CanAddEmployee());
            UpdateEmployeeCommand = new RelayCommand(c => UpdateEmployee(), c => SelectedEmployee != null);
            RemoveEmployeeCommand = new RelayCommand(c => RemoveEmployee(), c => SelectedEmployee != null);
        }

        private bool CanAddEmployee()
        {
            if (string.IsNullOrWhiteSpace(Firstname) || string.IsNullOrWhiteSpace(Lastname))
                return false;

            return true;
        }

        private void AddEmployee()
        {
            var employee = new EmployeeViewModel(Firstname, Middlename, Lastname, new Company(CompanyName));
            Employees.Add(employee);
        }

        private void UpdateEmployee()
        {
            SelectedEmployee.Firstname = Firstname;
            SelectedEmployee.Middlename = Middlename;
            SelectedEmployee.Lastname = Lastname;
        }

        private void RemoveEmployee()
        {
            Employees.Remove(SelectedEmployee);
        }
    }
}
