using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Course
    {
        [Display(Name ="Course || Subject Name")]
        public int courseId { get; set; }
        public string CourseName { get; set; }
        public List<Addmission> Addmissions { get; set; }
        public Store Store { get; set; }
        public List<Purchase> purchases { get; set; }
        public List<Salles> Salles { get; set; }
    }
}
