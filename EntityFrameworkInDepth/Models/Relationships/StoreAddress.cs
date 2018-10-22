using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkInDepth.Models.Relationships
{
    public class StoreAddress : BaseEntity
    {
        public string Location { get; set; }
        public double Landitute { get; set; }
        public double Longitude { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
