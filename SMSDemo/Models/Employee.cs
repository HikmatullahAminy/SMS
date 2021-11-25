using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Employee
    {
        [Display(Name ="Teacher")]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
       
        [Display(Name = "Employee Address")]
        public string EmployeeAddress { get; set; }
        [Display(Name = "Employee Phone Number")]
        public int EmployeePhoneNumber { get; set; }
        [Display(Name = "Employee Sallary")]
        public int EmployeeSallary { get; set; }

        public List<Sallary> Sallaries { get; set; }
        public List<Expense> Expenses { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<Addmission> Addmissions { get; set; }
    }
}
