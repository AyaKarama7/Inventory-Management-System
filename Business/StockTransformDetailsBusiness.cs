using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class StockTransformDetailsBusiness
    {
        public static bool Insert(int transformId,int itemCode,int itemAmount,DateTime production,DateTime expiry)
        {
            using(var context=new AppDbContext())
            {
                var itemDetails = new StockTransformDetails
                {
                    TransformID=transformId,
                    ItemCode=itemCode,
                    ItemAmount=itemAmount,
                    ProductionDate=production,
                    ExpiryDate=expiry,
                };
                return true;
            }
        }
        public static List<StockTransformDetails>SelectTransformedItems(List<string> transformID)
        {
            using(var context=new AppDbContext())
            {
                var items = context.StockTransformDetails.
                    Where(i => transformID.Contains(i.TransformID.ToString())).ToList();
                return items; ;
            }
        }
    }
}
