using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
    public partial class Items
    {
        public Items()
        {
            Orders = new HashSet<Orders>();
        }

        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
