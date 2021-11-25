using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class ExpenseType
    {
        [Key]
        public int ExpTypeId { get; set; }
        [Display(Name ="Expense Type Name")]
        public string ExpensTypeName { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}
