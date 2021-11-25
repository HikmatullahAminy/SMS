using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public int courseId { get; set; }
        public Course Course { get; set; }
        public int quantity { get; set; }

      

    }
}
