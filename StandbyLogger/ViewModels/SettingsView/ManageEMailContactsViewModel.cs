using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class ManageEMailContactsViewModel : BaseViewModel
    {
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(); }
        }

        private string _eMailAddress;
        public string EMailAddress
        {
            get { return _eMailAddress; }
            set { _eMailAddress = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<EMailContactViewModel> _eMailContacts;
        public ObservableCollection<EMailContactViewModel> EMailContacts
        {
            get { return _eMailContacts; }
            set { _eMailContacts = value; NotifyPropertyChanged(); }
        }

        private EMailContactViewModel _selectedEMailContact;
        public EMailContactViewModel SelectedEMailContact
        {
            get { return _selectedEMailContact; }
            set
            {
                _selectedEMailContact = value;
                NotifyPropertyChanged();

                if (value != null)
                {
                    Description = value.Description;
                    EMailAddress = value.EMailAddress;
                }
            }
        }

        public RelayCommand AddEMailContactCommand { get; set; }
        public RelayCommand UpdateEMailContactCommand { get; set; }
        public RelayCommand RemoveEMailContactCommand { get; set; }

        public ManageEMailContactsViewModel()
        {
            EMailContacts = new ObservableCollection<EMailContactViewModel>();
            AddEMailContactCommand = new RelayCommand(c => AddEMailContact(), c => CanAddEMailContact());
            UpdateEMailContactCommand = new RelayCommand(c => UpdateEMailContact(), c => SelectedEMailContact != null);
            RemoveEMailContactCommand = new RelayCommand(c => RemoveEMailContact(), c => SelectedEMailContact != null);
        }

        private bool CanAddEMailContact()
        {
            if (string.IsNullOrWhiteSpace(Description))
                return false;

            if (string.IsNullOrWhiteSpace(EMailAddress))
                return false;

            if (!EMailAddress.Contains('@'))
                return false;

            return true;
        }

        private void AddEMailContact()
        {
            var eMailContact = new EMailContactViewModel(Description, EMailAddress);
            EMailContacts.Add(eMailContact);
        }

        private void UpdateEMailContact()
        {
            SelectedEMailContact.Description = Description;
            SelectedEMailContact.EMailAddress = EMailAddress;
        }

        private void RemoveEMailContact()
        {
            EMailContacts.Remove(SelectedEMailContact);
        }
    }
}
