using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class DataServices
    {
        public List<Fruit> Fruits { get; set; }
        public List<Vegetable> Vegetables { get; set; }
        public List<Dishware> Dishwares { get; set; }


        public DataServices()
        {
            Fruits= new List<Fruit>();

            Vegetables= new List<Vegetable>();

            Dishwares = new List<Dishware>();

        }
    }
}
