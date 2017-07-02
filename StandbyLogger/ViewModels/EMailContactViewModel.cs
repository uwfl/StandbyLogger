using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class EMailContactViewModel : BaseViewModel
    {
        public EMailContact EMailContact { get; private set; }

        public string Description
        {
            get { return EMailContact.Description; }
            set { EMailContact.Description = value; NotifyPropertyChanged(); }
        }

        public string EMailAddress
        {
            get { return EMailContact.EMailAddress; }
            set { EMailContact.EMailAddress = value; NotifyPropertyChanged(); }
        }

        public EMailContactViewModel(EMailContact eMailContact)
        {
            EMailContact = eMailContact;
        }

        public EMailContactViewModel(string description, string eMailAddress)
        {
            EMailContact = new EMailContact(description, eMailAddress);
        }
    }
}
