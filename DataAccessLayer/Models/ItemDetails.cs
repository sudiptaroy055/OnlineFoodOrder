using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ItemDetails
    {
        [Key]
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}
