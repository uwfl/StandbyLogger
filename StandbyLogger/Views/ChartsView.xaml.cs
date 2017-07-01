using StandbyLogger.ViewModels;
using System.Windows.Controls;

namespace StandbyLogger.Views
{
    /// <summary>
    /// Interaction logic for ChartsView.xaml
    /// </summary>
    public partial class ChartsView : UserControl
    {
        private ChartsViewModel _vm;
        public ChartsViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                this.DataContext = _vm;
            }
        }

        public ChartsView()
        {
            InitializeComponent();
        }
    }
}
