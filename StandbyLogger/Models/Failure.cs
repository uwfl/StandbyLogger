using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class Failure
    {
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string ActionsTaken { get; set; }
    }
}
