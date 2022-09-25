using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.Models
{
    public class Items
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

    }
}
