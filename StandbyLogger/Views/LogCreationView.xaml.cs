using StandbyLogger.ViewModels;
using System.Windows.Controls;

namespace StandbyLogger.Views
{
    /// <summary>
    /// Interaction logic for LogCreationView.xaml
    /// </summary>
    public partial class LogCreationView : UserControl
    {
        private LogCreationViewModel _vm;
        public LogCreationViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                this.DataContext = _vm;
            }
        }

        public LogCreationView()
        {
            InitializeComponent();
        }
    }
}
