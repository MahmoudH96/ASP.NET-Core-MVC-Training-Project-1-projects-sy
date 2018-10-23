using System;
using System.Collections.Generic;
using System.Text;

namespace LINQToEntityFramework.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
