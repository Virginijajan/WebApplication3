using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos.Base;

namespace WebApplication3.Dtos
{
    public class ShopItemDto:DtoObject
    {
        public string Category { get; set; }

        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public int ShopId { get; set; }


    }
}
