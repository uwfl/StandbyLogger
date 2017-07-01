using StandbyLogger.ViewModels;
using System.Windows.Controls;

namespace StandbyLogger.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private HomeViewModel _vm;
        public HomeViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                this.DataContext = _vm;
            }
        }

        public HomeView()
        {
            InitializeComponent();
        }
    }
}
