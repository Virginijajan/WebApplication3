using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos.Base;

namespace WebApplication3.Dtos
{
    public class OrderItemDto:DtoObject
    {
        public string Category { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
       
    }
}
