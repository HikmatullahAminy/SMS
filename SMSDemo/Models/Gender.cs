
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Gender
    {   
        [Display(Name ="Gender")]
        public int GenderId{ get; set; }
        [Display(Name ="Gender")]
        public string GenderName { get; set; }

        public List<Student>  Student { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
