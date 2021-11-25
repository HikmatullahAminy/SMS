using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSDemo.Models
{
    public class Banke
    {
        public int BankeId { get; set; }
        [Display(Name =("Exist Amount"))]
        public int AmountExist { get; set; }

    }
}
