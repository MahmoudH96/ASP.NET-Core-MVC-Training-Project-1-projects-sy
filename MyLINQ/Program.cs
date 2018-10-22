using MyLINQ.Models;
using System;

namespace MyLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing my Linq library");
            var dataList = MockDb.GetAllMobiles();
            var mobiles = dataList.Where(mobile => mobile.Price > 700);
            Console.WriteLine("List of mobiles with price more than 700");
            foreach (var mobile in mobiles)
            {
                Console.WriteLine($"Mobile name: {mobile.Name}, with price {mobile.Price}");
            }
            var firstIPhone = dataList.FirstOrDefault(mobile => mobile.Name.ToLower().Contains("iphone"));
            if (firstIPhone != null)
            {
                Console.WriteLine($"The first IPhone inside the database is {firstIPhone.Name}, with price {firstIPhone.Price}");
            }
            else
            {
                Console.WriteLine("We don't have any IPhones");
            }
        }
    }
}
