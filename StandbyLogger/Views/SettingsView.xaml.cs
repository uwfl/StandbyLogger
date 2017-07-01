using StandbyLogger.ViewModels;
using System.Windows.Controls;

namespace StandbyLogger.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private SettingsViewModel _vm;
        public SettingsViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                this.DataContext = _vm;
            }
        }

        public SettingsView()
        {
            InitializeComponent();
        }
    }
}
