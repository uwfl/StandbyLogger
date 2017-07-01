using StandbyLogger.ViewModels;
using System.Windows.Controls;

namespace StandbyLogger.Views
{
    /// <summary>
    /// Interaction logic for ServiceLogView.xaml
    /// </summary>
    public partial class ServiceLogView : UserControl
    {
        private ServiceLogViewModel _vm;
        public ServiceLogViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                this.DataContext = _vm;
            }
        }

        public ServiceLogView()
        {
            InitializeComponent();
        }
    }
}
