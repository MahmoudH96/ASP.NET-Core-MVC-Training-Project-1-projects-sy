using LINQToEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQToEntityFramework.Repositories
{
    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> GetAllWarehourses(string query);
        int GetTotalBooksCount();
        int GetBookCopiesCount(int bookId);
        double GetBookCopiesPrice(int bookId);
        IEnumerable<Order> GetAllCustomerOrders(int customerId);
        Order GetLatestOrder();
        IDictionary<Author, IEnumerable<Book>> GetAuthorsBook();
        double GetOrderValuesForMonth(int month, int year);
        IEnumerable<Warehouse> GetPublisherWarehourses(int publisherId);
        double GetAuthorTotalSalles(int authorId);
        IDictionary<string, int> GetBooksTotalSallesCopies();

    }
}
