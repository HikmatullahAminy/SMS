using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Student
    {
        [Display(Name="Student Name")]
        public int StudentId { get; set; }
        [Display(Name ="Student Name")]
        public string StudentName { get; set; }
        [Display(Name ="Father Name")]
        public string FatherName { get; set; }
        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public List<Addmission> Addmissions { get; set; }
    }
}
