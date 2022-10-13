using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.Models
{
    public class Item
    {
        [Required]
        public string ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
