using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int CourseId { get; set; }
        public Course   Course { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }

    }
}
