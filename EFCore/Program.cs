using EFCore.SqlServer;
using System;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CompanyDbContext())
            {
                var departments = context.Departments.ToList();
                foreach (var department in departments)
                {
                    Console.WriteLine($"Id:{department.Id}, name:{department.Name}, description:{department.Description}");
                }
            }
        }
    }
}
