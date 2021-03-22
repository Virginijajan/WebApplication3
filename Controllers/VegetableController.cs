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
    public class VegetableController : ControllerBase
    {    

       // private readonly DataServices _dataServices;

       // public VegetableController(DataServices dataServices)
        //{
          //  _dataServices = dataServices;
       // }
       
        private readonly DataContext _context;

        public VegetableController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        [HttpGet]
        public List<Vegetable> GetAll()
        {
            //return _dataServices.Vegetables;
            return _context.Vegetables.ToList();
        }


        [HttpGet("{id}")]
        public Vegetable GetById(int id)
        {

          //  var item = _dataServices.Vegetables.FirstOrDefault(i => i.Id == id);
            var item = _context.Vegetables.FirstOrDefault(s => s.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            return item;
        }


        [HttpPost]
        public void Create(Vegetable item)
        {
            //_dataServices.Vegetables.Add(item);
            _context.Add(item);
            _context.SaveChanges();
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // var item = _dataServices.Vegetables.FirstOrDefault(i => i.Id == id);
            var item = _context.Vegetables.FirstOrDefault(s => s.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException();
            }
           // _dataServices.Vegetables.Remove(item);
            _context.Remove(item);
            _context.SaveChanges();
        }



        [HttpPut]

        public void Update(Vegetable item)
        {
            //var vegetableToReplace = _dataServices.Vegetables.FirstOrDefault(i => i.Id == item.Id);
            //var ind = _dataServices.Vegetables.FindIndex(i => i.Id == item.Id);

           // if (vegetableToReplace == null)
           // {
             //   throw new KeyNotFoundException();
          //  }
            //_dataServices.Vegetables[ind] = item;
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
