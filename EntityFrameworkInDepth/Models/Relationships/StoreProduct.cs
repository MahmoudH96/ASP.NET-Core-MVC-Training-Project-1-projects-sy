using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkInDepth.Models.Relationships
{
    public class StoreProduct : BaseEntity
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
