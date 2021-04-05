using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities.Base
{
    public class ShopItem:Entity
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ShopId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
