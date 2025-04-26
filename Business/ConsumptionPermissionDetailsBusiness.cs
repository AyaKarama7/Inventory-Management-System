using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ConsumptionPermissionDetailsBusiness
    {
        public static bool Insert(int customerId,int itemCode, int itemAmount)
        {
            using (var context = new AppDbContext())
            {
                var itemDetails = new ConsumptionPermissionDetails
                {
                    ConsumptionID=customerId,
                    ItemCode = itemCode,
                    ItemAmount = itemAmount,
                };
                return true;
            }
        }
        public static List<ConsumptionPermissionDetails> SelectItems(List<string> consumptionID)
        {
            using (var context = new AppDbContext())
            {
                var items = context.ConsumptionPermissionDetails.
                    Where(i => consumptionID.Contains(i.ConsumptionID.ToString())).ToList();
                return items;
            }
        }
    }
}
