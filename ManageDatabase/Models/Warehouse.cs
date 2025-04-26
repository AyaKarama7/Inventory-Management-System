using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class Warehouse
    {
        [Key]
        public string? WarehouseName { get; set; }
        public string? WarehouseAddress { get; set; }
        public int? WarehouseMangerId { get; set; }
        [IgnoreDataMember]
        public List<ConsumptionPermission>? Permissions { get; set; }
        [IgnoreDataMember]
        public List<StockTransform>? From { get; set; }
        [IgnoreDataMember]
        public List<StockTransform>? To { get; set; }
        [IgnoreDataMember]
        public List<SupplingPermission>? SupplingPermissions { get; set; }
        [IgnoreDataMember]
        public Employee? Employee { get; set; }
        [IgnoreDataMember]
        public List<ItemWarehouse>? ItemWarehouses { get; set; }

    }
}
