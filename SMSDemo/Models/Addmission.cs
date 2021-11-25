using SMSDemo.Data;
using SMSDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Addmission
    {
        public int AddmissionId { get; set; }
        [Display(Name ="Student Name")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Fees { get; set; }
        [Display(Name ="Course Or Subject Name")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey("EmployeeId")]
        [Display(Name ="Teacher")]
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("TimeId")]
        public int TimeId { get; set; }
        public Time Time { get; set; }

    }
}
