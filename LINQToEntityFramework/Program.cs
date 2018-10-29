using LINQToEntityFramework.Repositories;
using LINQToEntityFramework.SqlServer;
using LINQToEntityFramework.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LINQToEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            IWarehouseRepository warehouseRepository = new WarehouseRepository(new WarehouseDbContext());
            warehouseRepository.GetPublisherWarehourses(1);
        }

        static void CompareIncludeQueryWithoutInclude()
        {
            using (var context = new WarehouseDbContext())
            {
                var filterQueryWithInclude = context.Books.AsNoTracking()
                    .Include(book => book.Author)
                    .Where(book => book.Author.FirstName.Contains("A"));
                var filterQueryWithoutInclude = context.Books.AsNoTracking()
                    .Where(book => book.Author.FirstName.Contains("A"));

                Console.WriteLine("Filter query with include:");
                Console.WriteLine(filterQueryWithInclude.ToSql());
                Console.WriteLine("---------------------------------------\n");

                Console.WriteLine("Filter query without include:");
                Console.WriteLine(filterQueryWithoutInclude.ToSql());
                Console.WriteLine("---------------------------------------\n");
            }
        }
    }
}
