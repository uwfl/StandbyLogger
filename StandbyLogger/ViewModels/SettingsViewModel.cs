using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Settings Settings { get; private set; }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        private ObservableCollection<Informer> _informers;
        public ObservableCollection<Informer> Informers
        {
            get { return _informers; }
            set { _informers = value; }
        }

        private ObservableCollection<string> _failureTypes;
        public ObservableCollection<string> FailureTypes
        {
            get { return _failureTypes; }
            set { _failureTypes = value; }
        }

        private ObservableCollection<string> _emailTo;
        public ObservableCollection<string> EmailTo
        {
            get { return _emailTo; }
            set { _emailTo = value; }
        }

        private ObservableCollection<string> _emailCC;
        public ObservableCollection<string> EmailCC
        {
            get { return _emailCC; }
            set { _emailCC = value; }
        }

        [XmlIgnore]
        public RelayCommand AddEmployeeCommand { get; set; }
        public RelayCommand AddInformerCommand { get; set; }
        public RelayCommand AddFailureTypeCommand { get; set; }
        public RelayCommand AddEmailToCommand { get; set; }
        public RelayCommand AddEmailCCCommand { get; set; }
        public RelayCommand SaveSettingsCommand { get; set; }

        public SettingsViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            Informers = new ObservableCollection<Informer>();
            FailureTypes = new ObservableCollection<string>();

            SaveSettingsCommand = new RelayCommand(c => SaveSettings(), c => true);
        }

        public void ReadSettings()
        {
            if(!System.IO.File.Exists(Utilities.Constants.PATH_SETTINGS))
            {
                Settings = new Settings(fallback: true);
                Utilities.SerializingHelper.Serialize(Settings, Utilities.Constants.PATH_SETTINGS);
            }
            else
            {
                Settings = Utilities.SerializingHelper.Deserialize<Settings>(Utilities.Constants.PATH_SETTINGS);
            }

            // Copy values to the current display VM.
            Employees = new ObservableCollection<Employee>(Settings.Employees);
            Informers = new ObservableCollection<Informer>(Settings.Informers);
            FailureTypes = new ObservableCollection<string>(Settings.FailureTypes);
        }

        public void SaveSettings()
        {
            Settings.Employees = Employees.ToList();
            Settings.Informers = Informers.ToList();
            Settings.FailureTypes = FailureTypes.ToList();

            Utilities.SerializingHelper.Serialize(Settings, Utilities.Constants.PATH_SETTINGS);
        }
    }
}
