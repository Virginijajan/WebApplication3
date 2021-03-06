using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;
using WebApplication3.Entities.Base;

namespace WebApplication3.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async override Task<List<Order>> GetAll()
        {
            return await _context.Set<Order>().ToListAsync();
        }



        public override Order FindById(int id)
        {

            var entity = _context.Set<Order>().FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                throw new ArgumentException("");
            }

            return entity;
        }




        public async Task UpdateShopItem(ShopItem entity)
        {
            var id = _context.ShopItems.FirstOrDefault(s => s.Id == entity.Id);

            if (id != null)
            {
                _context.Update(entity);
            }
            else
            {
                throw new ArgumentNullException();
            }
            await _context.SaveChangesAsync();
        }

        public virtual ShopItem GetShopItem(string name)
        {
            var entity = _context.Set<ShopItem>().FirstOrDefault(e => e.Name == name);

            if (entity == null)
            {
                throw new ArgumentException("");
            }

            return entity;
        }
    }
}
