using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public int Amount { get; set; }
        public DateTime Date{ get; set; }

           [ForeignKey("EmployeeId")]
           [Display(Name ="Which Employee Did")]
         public int EmployeeId { get; set; }
         public Employee  Employee { get; set; }

         [ForeignKey("ExpTypeId")]
         [Display(Name ="Expense Type")]
         public int ExpTypeId { get; set; }
         public ExpenseType ExpenseType { get; set; }
    }
}
