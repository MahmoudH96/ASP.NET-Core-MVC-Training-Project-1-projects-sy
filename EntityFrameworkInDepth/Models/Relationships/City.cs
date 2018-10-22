using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkInDepth.Models.Relationships
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Store> Stories { get; set; }
    }
}
