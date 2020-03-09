using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.Models
{
    public class Bank
    {
        public String code { get; set; }
        
        [MaxLength(50)]
        public String name { get; set; }
        public String contactName { get; set; }
        public String contactPhone { get; set; }
    }
}
