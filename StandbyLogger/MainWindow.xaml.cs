using Microsoft.Practices.Unity;
using StandbyLogger.ViewModels;
using System.Windows;

namespace StandbyLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;
        public MainViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                this.DataContext = _vm;
            }
        }

        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            VM = vm;
        }
    }
}
