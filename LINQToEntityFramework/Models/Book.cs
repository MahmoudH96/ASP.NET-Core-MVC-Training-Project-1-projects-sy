using LINQToEntityFramework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQToEntityFramework.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int PageCount { get; set; }
        public CoverType CoverType { get; set; }

        public ICollection<Order> Orders { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
