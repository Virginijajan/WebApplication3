using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities.Base;

namespace WebApplication3.Entities
{
    public class Shop : Entity
    {
        public string Name { get; set; }
        public List<ShopItem>ShopItems{get;set;}

    }
}
