using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Dtos;
using WebApplication3.Entities;
using WebApplication3.Entities.Base;

namespace WebApplication3.Repositories
{
    public class GenericRepository<T> where T: Entity
    {
        private readonly DataContext _context;
       

        public GenericRepository(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
           
        }

        public async Task <List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public T FindById(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                throw new ArgumentException("");
            }

            return entity;
        }


        public async Task Upsert(T entity)
        {
          
            if (entity.Id==0)
            {
                _context.Add(entity);
               
            }
            else 

            {
                _context.Update(entity);
            }
            await _context.SaveChangesAsync();
        }


        public async Task Delete(int id)
        {

            var entity=_context.Set<T>().FirstOrDefault(e=>e.Id==id);
            if (entity != null)
            {
                _context.Remove(entity);
            }
           
            await _context.SaveChangesAsync();
        }
    }
}
