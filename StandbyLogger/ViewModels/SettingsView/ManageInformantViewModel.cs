using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class ManageInformantViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }
        private ObservableCollection<InformerViewModel> _informants;
        public ObservableCollection<InformerViewModel> Informants
        {
            get { return _informants; }
            set { _informants = value; NotifyPropertyChanged(); }
        }

        private InformerViewModel _selectedInformer;
        public InformerViewModel SelectedInformer
        {
            get { return _selectedInformer; }
            set
            {
                _selectedInformer = value;
                NotifyPropertyChanged();

                if (value != null)
                {
                    Name = value.Name;
                }
            }
        }

        public RelayCommand AddInformerCommand { get; set; }
        public RelayCommand UpdateInformerCommand { get; set; }
        public RelayCommand RemoveInformerCommand { get; set; }

        public ManageInformantViewModel()
        {
            Informants = new ObservableCollection<InformerViewModel>();
            AddInformerCommand = new RelayCommand(c => AddInformer(), c => CanAddInformer());
            UpdateInformerCommand = new RelayCommand(c => UpdateInformer(), c => SelectedInformer != null);
            RemoveInformerCommand = new RelayCommand(c => RemoveInformer(), c => SelectedInformer != null);
        }

        private bool CanAddInformer()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;

            return true;
        }

        private void AddInformer()
        {
            var informer = new InformerViewModel(Name);
            Informants.Add(informer);
        }

        private void UpdateInformer()
        {
            SelectedInformer.Name = Name;
        }

        private void RemoveInformer()
        {
            Informants.Remove(SelectedInformer);
        }
    }
}
