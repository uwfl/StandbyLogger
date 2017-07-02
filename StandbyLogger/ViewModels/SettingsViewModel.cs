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
        public ManageEmployeeViewModel EmployeeVM { get; set; }
        public ManageInformantViewModel InformantVM { get; set; }
        public ManageFailureTemplatesViewModel FailureTemplateVM { get; set; }
        public ManageEMailContactsViewModel EMailContactsVM { get; set; }

        public RelayCommand AddEmployeeCommand { get; set; }
        public RelayCommand AddInformerCommand { get; set; }
        public RelayCommand AddFailureTypeCommand { get; set; }
        public RelayCommand AddEmailToCommand { get; set; }
        public RelayCommand AddEmailCCCommand { get; set; }
        public RelayCommand SaveSettingsCommand { get; set; }

        public SettingsViewModel()
        {
            EmployeeVM = new ManageEmployeeViewModel();
            InformantVM = new ManageInformantViewModel();
            EMailContactsVM = new ManageEMailContactsViewModel();
            FailureTemplateVM = new ManageFailureTemplatesViewModel();

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
            EmployeeVM.Employees = new ObservableCollection<EmployeeViewModel>(Settings.Employees.Select(e => new EmployeeViewModel(e)));
            InformantVM.Informants = new ObservableCollection<InformerViewModel>(Settings.Informers.Select(i => new InformerViewModel(i)));
            FailureTemplateVM.FailureTemplates = new ObservableCollection<FailureTemplateViewModel>(Settings.FailureTypes.Select(ft => new FailureTemplateViewModel(ft)));
            EMailContactsVM.EMailContacts = new ObservableCollection<EMailContactViewModel>(Settings.EMailContacts.Select(e => new EMailContactViewModel(e)));
        }

        public void SaveSettings()
        {
            try
            {
                // Copy all VM values to the settings object.
                Settings.Employees = EmployeeVM.Employees.Select(e => e.Employee).ToList();
                Settings.Informers = InformantVM.Informants.Select(i => i.Informer).ToList();
                Settings.FailureTypes = FailureTemplateVM.FailureTemplates.Select(ft => ft.FailureType).ToList();
                Settings.EMailContacts = EMailContactsVM.EMailContacts.Select(e => e.EMailContact).ToList();

                // Serialize as XML file.
                Utilities.SerializingHelper.Serialize(Settings, Utilities.Constants.PATH_SETTINGS);
                System.Windows.MessageBox.Show("Alle Einstellungen wurden vollständig gespeichert.", "Speichern erfolgreich", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Fehler beim speichern der Daten.", "Fehler: Keine Speicherung möglich", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Stop);
            }
        }
    }
}
