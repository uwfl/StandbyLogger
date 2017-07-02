using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class InformerViewModel : BaseViewModel
    {
        public Informer Informer { get; private set; }

        public string Name
        {
            get { return Informer.Name; }
            set { Informer.Name = value; NotifyPropertyChanged(); }
        }

        public InformerViewModel(Informer informer)
        {
            this.Informer = informer;
        }

        public InformerViewModel(string name)
        {
            Informer = new Informer(name);
        }
    }
}
