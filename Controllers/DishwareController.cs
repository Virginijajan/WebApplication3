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
   
    public class DishwareController : ControllerBase

    {

    // private readonly DataServices _dataServices;

    //  public DishwareController(DataServices dataServices)
    // {
    //_dataServices = dataServices;
    // }

    
        private readonly DataContext _context;

        public DishwareController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        [HttpGet]
        public List<Dishware> GetAll()
        {
            // return _dataServices.Dishwares;
            return _context.Dishwares.ToList();
        }


        [HttpGet("{id}")]
        public Dishware GetById(int id)
        {

            // var item = _dataServices.Dishwares.FirstOrDefault(i => i.Id == id);
            var item = _context.Dishwares.FirstOrDefault(s => s.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            return item;
        }


        [HttpPost]
        public void Create(Dishware item)
        {
            //_dataServices.Dishwares.Add(item);
            _context.Add(item);
            _context.SaveChanges();
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // var item = _dataServices.Dishwares.FirstOrDefault(i => i.Id == id);
            var item = _context.Dishwares.FirstOrDefault(s => s.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            // _dataServices.Dishwares.Remove(item);

            _context.Remove(item);
            _context.SaveChanges();
        }



        [HttpPut]

        public void Update(Dishware item)
        {
            //var itemToReplace = _dataServices.Dishwares.FirstOrDefault(i => i.Id == item.Id);
            // var ind = _dataServices.Dishwares.FindIndex(i => i.Id == item.Id);

            // if (itemToReplace == null)
            //  {
            //  throw new KeyNotFoundException();
            //  }
            //_dataServices.Dishwares[ind] = item;
            _context.Update(item);
            _context.SaveChanges();

        }
    }
}
