using System;
using System.Collections.Generic;
using System.Text;

namespace LINQToEntityFramework.Models
{
    public class BookWarehouse : BaseEntity
    {
        public int Amount { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
