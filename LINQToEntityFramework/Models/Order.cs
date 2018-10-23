using System;
using System.Collections.Generic;
using System.Text;

namespace LINQToEntityFramework.Models
{
    public class Order : BaseEntity
    {
        public int BooksCount { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
