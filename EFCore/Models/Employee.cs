using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
