using LINQToEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQToEntityFramework.Models
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }

        public ICollection<BookWarehouse> BookWarehouses { get; set; }

        public Warehouse()
        {
            BookWarehouses = new HashSet<BookWarehouse>();
        }
    }
}
