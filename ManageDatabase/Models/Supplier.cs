using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class Supplier
    {
        [Key]
        public string? SupplierName { get; set; }
        public string? SupplierPhone { get; set; }
        public string? SupplierFax { get; set; }
        public string? SupplierEmail { get; set; }
        public string? SupplierWebsite { get; set; }
        public string? SupplierMobile { get; set; }
        public List<StockTransform>? Transforms { get; set; }
        public List<SupplingPermission>? SupplingPermissions { get; set; }
    }
}
