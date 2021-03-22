using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {

    // private readonly DataServices _dataServices;

    //  public FruitController(DataServices dataServices)
    //  {
    //_dataServices = dataServices;
    //  }
   
        private readonly DataContext _context;

        public FruitController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        [HttpGet]
        public List<Fruit> GetAll()
        {
           // return _dataServices.Fruits;
            return _context.Fruits.ToList();
        }


        [HttpGet("{id}")]
        public Fruit GetById(int id)
        {

          //  var fruit = _dataServices.Fruits.FirstOrDefault(i => i.Id == id);
            var fruit = _context.Fruits.FirstOrDefault(s => s.Id == id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }
            return fruit;
        }

         
        [HttpPost]
        public void Create(Fruit item)
        {
           // _dataServices.Fruits.Add(item);
            _context.Add(item);
            _context.SaveChanges();
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // var fruit = _dataServices.Fruits.FirstOrDefault(i => i.Id == id);
            var fruit = _context.Fruits.FirstOrDefault(s => s.Id == id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }
            //_dataServices.Fruits.Remove(fruit);
            _context.Remove(fruit);
            _context.SaveChanges();
        }



        [HttpPut]

        public void Update(Fruit fruit)
        {
           // var fruitToReplace = _dataServices.Fruits.FirstOrDefault(i => i.Id == fruit.Id);
           // var ind = _dataServices.Fruits.FindIndex(i => i.Id == fruit.Id);

           // if (fruitToReplace == null)
          //  {
             //   throw new KeyNotFoundException();
           // }
            //_dataServices.Fruits[ind] = fruit;
            _context.Update(fruit);
            _context.SaveChanges();

        }
    }
}
