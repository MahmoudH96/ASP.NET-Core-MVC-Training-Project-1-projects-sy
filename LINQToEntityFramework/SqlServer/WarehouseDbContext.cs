using LINQToEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQToEntityFramework.SqlServer
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookWarehouse> BookWarehouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WarehouseDb;Integrated Security=True");
        }
    }
}
