using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class StockTransformBusiness
    {
        public static bool Insert(string from,string to,string supplierName)
        {
            using(var context=new AppDbContext())
            {
                var transform = new StockTransform 
                { 
                    FromWarehouse = from,
                    ToWarehouse = to, 
                    SupplierName = supplierName 
                };
                context.StockTransforms.Add(transform);
                context.SaveChanges();
                return true;
            }
        }
        public static List<StockTransform>SelectAll()
        {
            using(var context=new AppDbContext())
            {
                var transforms = context.StockTransforms.ToList();
                return transforms;
            }
        }
    }
}
