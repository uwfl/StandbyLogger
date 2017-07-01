using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class Settings
    {
        public List<Employee> Employees { get; set; }
        public List<Informer> Informers { get; set; }
        public List<string> FailureTypes { get; set; }

        public List<string> EmailTo { get; set; }
        public List<string> EmailCC { get; set; }

        public Settings()
        {
            Employees = new List<Employee>();
            Informers = new List<Informer>();
            FailureTypes = new List<string>();
            EmailTo = new List<string>();
            EmailCC = new List<string>();
        }

        public Settings(bool fallback = false)
            : this()
        {
            CreateFallback();
        }

        private void CreateFallback()
        {
            // Add base employees.
            Employees.Add(new Employee("Markus", "Voß", DateTime.Now, new Company("Familie Reckeweg")));
            Employees.Add(new Employee("Alfred", "Hache", DateTime.Now, new Company("Familie Reckeweg")));
            Employees.Add(new Employee("Lutz", "Kofalk", DateTime.Now, new Company("Familie Reckeweg")));
            Employees.Add(new Employee("Michael", "Kraus", DateTime.Now, new Company("Familie Reckeweg")));
            Employees.Add(new Employee("Markus", "Voß", DateTime.Now, new Company("Familie Reckeweg")));

            // Add base informers.
            Informers.Add(new Informer("Firma Conexis"));
            Informers.Add(new Informer("Familie Reckeweg"));

            // Add base failure types.
            FailureTypes.Add("Störung \"Wasser\"");
            FailureTypes.Add("Störung \"Klima\"");
            FailureTypes.Add("Störung \"Alarmanlage - Unscharf\"");
            FailureTypes.Add("Stromausfall");
            FailureTypes.Add("Sonstiges");
            FailureTypes.Add("Ausgelöste Brandmeldeanlage");
            FailureTypes.Add("Einbruchsalarm");

            // Add default emails.
            EmailTo.Add("michael.kraus@reckeweg.de");
            EmailCC.Add("Sabine.Penger-Meyer@reckeweg.de");
        }
    }
}
