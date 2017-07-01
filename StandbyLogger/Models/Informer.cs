using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class Informer
    {
        public string Nane { get; set; }

        public Informer(string name)
        {
            Nane = name;
        }
    }
}
