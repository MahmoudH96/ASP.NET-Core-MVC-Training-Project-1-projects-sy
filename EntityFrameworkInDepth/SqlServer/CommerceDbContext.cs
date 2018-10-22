using EntityFrameworkInDepth.Models;
using EntityFrameworkInDepth.Models.Relationships;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkInDepth.SqlServer
{
    public class CommerceDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreAddress> StoreAddresses { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CommerceDb;Integrated Security=True");
        }
    }
}
