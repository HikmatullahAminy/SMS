using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public Time time { get; set; }
        public List<Addmission> Addmissions { get; set; }
    }
}
