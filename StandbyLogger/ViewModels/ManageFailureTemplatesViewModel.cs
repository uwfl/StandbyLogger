using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class ManageFailureTemplatesViewModel : BaseViewModel
    {
        private string _failureType;
        public string FailureType
        {
            get { return _failureType; }
            set { _failureType = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<FailureTemplateViewModel> _failureTemplates;
        public ObservableCollection<FailureTemplateViewModel> FailureTemplates
        {
            get { return _failureTemplates; }
            set { _failureTemplates = value; NotifyPropertyChanged(); }
        }

        private FailureTemplateViewModel _selectedFailureTemplate;
        public FailureTemplateViewModel SelectedFailureTemplate
        {
            get { return _selectedFailureTemplate; }
            set
            {
                _selectedFailureTemplate = value;
                NotifyPropertyChanged();

                if (value != null)
                {
                    FailureType = value.FailureType;
                }
            }
        }

        public RelayCommand AddFailureTemplateCommand { get; set; }
        public RelayCommand UpdateFailureTemplateCommand { get; set; }
        public RelayCommand RemoveFailureTemplateCommand { get; set; }

        public ManageFailureTemplatesViewModel()
        {
            FailureTemplates = new ObservableCollection<FailureTemplateViewModel>();
            AddFailureTemplateCommand = new RelayCommand(c => AddFailureTemplate(), c => !string.IsNullOrWhiteSpace(FailureType) && !FailureTemplates.Any(ft => ft.FailureType == FailureType));
            UpdateFailureTemplateCommand = new RelayCommand(c => UpdateFailureTemplate(), c => SelectedFailureTemplate != null);
            RemoveFailureTemplateCommand = new RelayCommand(c => RemoveFailureTemplate(), c => SelectedFailureTemplate != null);
        }

        private void AddFailureTemplate()
        {
            var failureTemplate = new FailureTemplateViewModel(FailureType);
            FailureTemplates.Add(failureTemplate);
        }

        private void UpdateFailureTemplate()
        {
            SelectedFailureTemplate.FailureType = FailureType;
        }

        private void RemoveFailureTemplate()
        {
            FailureTemplates.Remove(SelectedFailureTemplate);
        }
    }
}
