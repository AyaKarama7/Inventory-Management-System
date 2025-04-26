using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class ConsumptionPermission
    {
        [Key]
        public int ConsumptionID { get; set; }
        public DateTime PermissionDate { get; set; }
        public string? WarehouseName { get; set; }
        public Warehouse? Warehouse { get; set; }
        public string? CustomerName { get; set; }
        public Customer? Customer { get; set; }
        public List<ConsumptionPermissionDetails>? PermissionDetails { get; set; }
    }
}
