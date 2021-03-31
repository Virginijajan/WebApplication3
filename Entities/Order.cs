using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities.Base;

namespace WebApplication3.Entities
{
    public class Order:Entity
    {
        public int ItemId { get; set; }

        public ShopItem Item { get; set; }

        public int Quantity { get; set; }

      

    }
}
