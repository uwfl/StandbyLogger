﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.Models
{
    public class LogEntryActor
    {
        public Employee Actor { get; set; }
        [XmlAttribute]
        public DateTime From { get; set; }
        [XmlAttribute]
        public DateTime To { get; set; }

        public LogEntryActor()
        { }

        public LogEntryActor(Employee actor, DateTime from, DateTime to)
        {
            Actor = actor;
            From = from;
            To = to;
        }

        public int DifferenceInMinutes
        {
            get
            {
                return (To - From).Minutes;
            }
        }
    }
}
