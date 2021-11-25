using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Sallary
    {
        public int SallaryId { get; set; }
        [Display(Name ="Sallary Amount")]
        public int EmployeeSallary { get; set; }
        public DateTime Date { get; set; }
        [Display(Name ="Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    

    }
}
