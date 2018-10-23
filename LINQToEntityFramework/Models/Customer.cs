using System;
using System.Collections.Generic;
using System.Text;

namespace LINQToEntityFramework.Models
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
