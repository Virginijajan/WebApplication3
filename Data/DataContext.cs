using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Data
{
    public class DataContext:DbContext

    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Fruit> Fruits { get; set; }

        public DbSet<Vegetable> Vegetables { get; set; }

        public DbSet<Dishware> Dishwares { get; set; }

        public DbSet<Shop> Shops { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
