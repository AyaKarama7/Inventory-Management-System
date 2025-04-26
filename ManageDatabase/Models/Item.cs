using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class Item
    {
        [Key]
        public int ItemCode { get; set; }
        public string? ItemName { get; set; }
        public List<ItemMeasureUnit>? ItemMeasureUnits { get; set; }
        public List<ConsumptionPermissionDetails>? PermissionDetails { get; set; }
        public List<StockTransformDetails>? StockTransformDetails { get; set; }
        public List<SupplingPermissionDetails>? SupplingPermissionDetails { get; set; }
        public List<ItemWarehouse>? ItemWarehouses { get; set; }
    }
}
