using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxStudents { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
