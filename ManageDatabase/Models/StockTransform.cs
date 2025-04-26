using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class StockTransform
    {
        [Key]
        public int TransformID { get; set; }
        public string? FromWarehouse { get; set; }
        public string? ToWarehouse { get; set; }
        public string? SupplierName { get; set; }
        public Supplier? Supplier { get; set; }
        public Warehouse? FWarehouse { get; set; }
        public Warehouse? TWarehouse { get; set; }
        public List<StockTransformDetails>? StockTransformDetails { get; set; }
    }
}
