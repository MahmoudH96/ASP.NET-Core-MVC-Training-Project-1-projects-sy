using LINQToEntityFramework.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using LINQToEntityFramework.Models;

namespace LINQToEntityFramework.Util
{
    public static class Seed
    {
        public static void SeedData()
        {
            using (var context = new WarehouseDbContext())
            {
                var author1 = new Author()
                {
                    FirstName = "John",
                    LastName = "Brown",
                    Address = "London"
                };
                context.Add(author1);
                context.SaveChanges();
                var author2 = new Author()
                {
                    FirstName = "Dan",
                    LastName = "Brown",
                    Address = "New York"
                };
                context.Add(author2);
                context.SaveChanges();

                var author3 = new Author()
                {
                    FirstName = "Mike",
                    LastName = "Green",
                    Address = "New York"
                };
                context.Add(author3);
                context.SaveChanges();

                var publisher1 = new Publisher()
                {
                    Name = "Wrox",
                    Website = "Wrox.com",
                    Address = "International"
                };
                context.Add(publisher1);
                context.SaveChanges();

                var publisher2 = new Publisher()
                {
                    Name = "Apress",
                    Website = "Apress.com",
                    Address = "International"
                };
                context.Add(publisher2);
                context.SaveChanges();

                var book1 = new Book()
                {
                    AuthorId = author1.Id,
                    PublisherId = publisher1.Id,
                    Title = "Getting started with entity framework core",
                    CoverType = Models.Enums.CoverType.PerfectBound,
                    Description = "Great book",
                    Price = 40,
                    PageCount = 350
                };
                context.Add(book1);
                context.SaveChanges();

                var book2 = new Book()
                {
                    AuthorId = author2.Id,
                    PublisherId = publisher1.Id,
                    Title = "Getting started with WPF",
                    CoverType = Models.Enums.CoverType.SaddleStitch,
                    Description = "Great book",
                    Price = 60,
                    PageCount = 300
                };
                context.Add(book2);
                context.SaveChanges();

                var book3 = new Book()
                {
                    AuthorId = author3.Id,
                    PublisherId = publisher2.Id,
                    Title = "Pro MVC",
                    CoverType = Models.Enums.CoverType.CoilBound,
                    Description = "Great book",
                    Price = 36,
                    PageCount = 500
                };
                context.Add(book3);
                context.SaveChanges();


                var warehouse1 = new Warehouse()
                {
                    Name = "Warehouse 1",
                    Location = "Germany",
                    Phone = "+2156323284"
                };
                warehouse1.BookWarehouses.Add(new BookWarehouse()
                {
                    BookId = book1.Id,
                    Amount = 5000
                });
                warehouse1.BookWarehouses.Add(new BookWarehouse()
                {
                    BookId = book2.Id,
                    Amount = 3000
                });
                context.Warehouses.Add(warehouse1);
                context.SaveChanges();

                var warehouse2 = new Warehouse()
                {
                    Name = "Warehouse 2",
                    Location = "London",
                    Phone = "+2156334284"
                };
                warehouse2.BookWarehouses.Add(new BookWarehouse()
                {
                    BookId = book2.Id,
                    Amount = 3874
                });
                warehouse2.BookWarehouses.Add(new BookWarehouse()
                {
                    BookId = book3.Id,
                    Amount = 364
                });
                context.Warehouses.Add(warehouse2);
                context.SaveChanges();

                var customer1 = new Customer()
                {
                    FullName = "Harvard Library"
                };
                customer1.Orders.Add(new Order()
                {
                    BooksCount = 250,
                    DateTime = new DateTime(2017, 1, 1),
                    BookId = book1.Id
                });
                customer1.Orders.Add(new Order()
                {
                    BooksCount = 300,
                    DateTime = new DateTime(2017, 5, 5),
                    BookId = book2.Id
                });

                customer1.Orders.Add(new Order()
                {
                    BooksCount = 30,
                    DateTime = new DateTime(2017, 5, 25),
                    BookId = book3.Id
                });
                context.Customers.Add(customer1);
                context.SaveChanges();

                var customer2 = new Customer()
                {
                    FullName = "Cambridge Library"
                };
                customer2.Orders.Add(new Order()
                {
                    BooksCount = 16,
                    DateTime = new DateTime(2017, 3, 24),
                    BookId = book1.Id
                });
                customer2.Orders.Add(new Order()
                {
                    BooksCount = 15,
                    DateTime = new DateTime(2017, 7, 5),
                    BookId = book2.Id
                });

                customer2.Orders.Add(new Order()
                {
                    BooksCount = 70,
                    DateTime = new DateTime(2017, 5, 17),
                    BookId = book3.Id
                });
                context.Customers.Add(customer2);
                context.SaveChanges();

            }
        }
    }
}
