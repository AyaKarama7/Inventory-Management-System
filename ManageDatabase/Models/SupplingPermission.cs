using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class SupplingPermission
    {
        [Key]
        public int SupplingID { get; set; }
        public DateTime PermissionDate { get; set; }
        public string? WarehouseName { get; set; }
        [IgnoreDataMember]
        public Warehouse? Warehouse { get; set; }
        public string? SupplierName { get; set; }
        [IgnoreDataMember]
        public Supplier? Supplier { get; set; }
        [IgnoreDataMember]
        public List<SupplingPermissionDetails>? SupplingPermissionDetails { get; set; }
    }
}
