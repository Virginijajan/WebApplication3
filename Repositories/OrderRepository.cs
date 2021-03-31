using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;

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
            return await _context.Set<Order>().Include(s=>s.Item).ToListAsync();
        }



        public override Order FindById(int id)
        {
            var entity = _context.Set<Order>().Include(s=>s.Item).FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                throw new ArgumentException("");
            }

            return entity;
        }

       

    }
}
