using System.Collections.Generic;
using System.Linq;
using LINQToEntityFramework.Models;
using LINQToEntityFramework.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace LINQToEntityFramework.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        public WarehouseDbContext Context { get; }
        public WarehouseRepository(WarehouseDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Order> GetAllCustomerOrders(int customerId)
        {
            return Context.Orders
                .Where(order => order.CustomerId == customerId)
                .ToList();
        }

        public IEnumerable<Warehouse> GetAllWarehourses(string query)
        {
            return Context.Warehouses.Where(warehourse =>
                                    string.IsNullOrEmpty(query)
                                    ||
                                    warehourse.Name.ToUpper().Contains(query.ToUpper())
                                ).ToList();
        }

        public IDictionary<Author, IEnumerable<Book>> GetAuthorsBook()
        {
            return Context.Authors
                    .ToDictionary(author => author, author => author.Books.AsEnumerable());
        }

        public double GetAuthorTotalSalles(int authorId)
        {
            return Context.Orders.Where(order => order.Book.AuthorId == authorId)
                .Sum(order => order.BooksCount * order.Book.Price);
        }

        public int GetBookCopiesCount(int bookId)
        {
            return Context.BookWarehouses
                .Where(bw => bw.BookId == bookId)
                .Sum(bw => bw.Amount);
        }

        public double GetBookCopiesPrice(int bookId)
        {
            return Context.BookWarehouses
                .Where(bw => bw.BookId == bookId)
                .Sum(bw => bw.Amount * bw.Book.Price);
        }

        public IDictionary<string, int> GetBooksTotalSallesCopies()
        {
            return Context.Books
                .Include(book => book.Orders) //without include this query will throw exception because we did not refere to it inside where condition
                .ToDictionary(book => book.Title
                            , book => book.Orders.Sum(order => order.BooksCount));
        }

        public Order GetLatestOrder()
        {
            var maxDateTime = Context.Orders.Max(order => order.DateTime);
            return Context.Orders.FirstOrDefault(order => order.DateTime == maxDateTime);

        }

        public double GetOrderValuesForMonth(int month, int year)
        {
            return Context.Orders
                .Where(order => order.DateTime.Year == year && order.DateTime.Month == month)
                .Sum(order => order.BooksCount * order.Book.Price);
        }

        public IEnumerable<Warehouse> GetPublisherWarehourses(int publisherId)
        {
            return Context.BookWarehouses.Where(bw => bw.Book.PublisherId == publisherId)
                    .Select(bw => bw.Warehouse).ToList();
        }

        public int GetTotalBooksCount()
        {
            return Context.BookWarehouses.Sum(book => book.Amount);
        }
    }
}
