using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkInDepth.Models.Relationships
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
