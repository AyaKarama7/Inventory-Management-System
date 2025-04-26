using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class SupplingPermissionDetailsBusiness
    {
        public static bool Insert(int supplingId,int itemCode, int itemAmount, DateTime production, DateTime expiry)
        {
            using (var context = new AppDbContext())
            {
                var itemDetails = new SupplingPermissionDetails
                {
                    SupplingID=supplingId,
                    ItemCode = itemCode,
                    ItemAmount = itemAmount,
                    ProductionDate = production,
                    ExpiryDate = expiry,
                };
                return true;
            }
        }
        public static List<SupplingPermissionDetails> SelectItems(List<string> supplingID)
        {
            using (var context = new AppDbContext())
            {
                var items = context.SupplingPermissionDetails.
                    Where(i => supplingID.Contains(i.SupplingID.ToString())).ToList();
                return items;
            }
        }
        public static List<SupplingPermissionDetails> SelectItemsNearExpire(int duration)
        {
            using (var context = new AppDbContext())
            {
                var items = context.SupplingPermissionDetails.
                    Where(i =>(i.ExpiryDate.Year-DateTime.Now.Year)==duration).ToList();
                return items;
            }
        }
    }
}
