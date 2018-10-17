using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
