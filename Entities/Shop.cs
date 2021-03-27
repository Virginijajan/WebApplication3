using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities.Base;

namespace WebApplication3.Entities
{
    public class Shop: Entity
    {
        public List<Dishware> Dishwares { get; set; }
        public List<Vegetable> Vegetables { get; set; }
        public List<Fruit> Fruits { get; set; }

    }
}
