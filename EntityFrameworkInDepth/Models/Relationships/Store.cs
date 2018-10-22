using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkInDepth.Models.Relationships
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public TimeSpan OpenHour { get; set; }
        public TimeSpan CloseHour { get; set; }
        public string Note { get; set; }
        public StoreAddress StoreAddress { get; set; }
        public ICollection<StoreProduct> StoreProducts { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
