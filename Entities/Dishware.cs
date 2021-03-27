using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities.Base;

namespace WebApplication3.Entities
{
    public class Dishware : Entity
    {
        public Shop shop {get; set;}

        public int ShopId { get; set; }

    }
}
