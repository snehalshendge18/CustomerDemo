using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDemo.Models
{
    public class CustomerFirstClass
    {
        [Key]
        [Required]
        public int CustmomerID { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Amount { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        public int Contact  { get; set; }

    }
}
