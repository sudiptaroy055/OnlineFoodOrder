using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class CategoryItemDetails
    {
        [Key]
        public int OrderId { get; set; }        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
