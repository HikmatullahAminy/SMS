using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Position
    {
        [Display(Name ="Position Name")]
        public int PositionId{ get; set; }
        [Display(Name ="Position Name")]
        public string PositionName { get; set; }
    
        public List<Employee> Employees { get; set; }
    }
}
