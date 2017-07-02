using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; NotifyPropertyChanged(); }
        }

        protected bool _isValid = true;
        public virtual bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; NotifyPropertyChanged(); }
        }

        private bool _isBusy;
        public virtual bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
