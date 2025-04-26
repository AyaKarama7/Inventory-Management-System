using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class ItemWarehouse
    {
        public int ItemCode { get; set; }
        public string? WarehouseName { get; set; }
        public int ItemAmount { get; set; }
        public Item? Item { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
