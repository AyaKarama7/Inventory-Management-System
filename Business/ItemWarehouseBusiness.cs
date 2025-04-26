using ManageDatabase.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ItemWarehouseBusiness
    {
        public static bool Insert(int itemCode, string warehouseName)
        {
            using(var context=new AppDbContext())
            {
                var itemWarhouse = new ItemWarehouse
                {
                    ItemCode = itemCode,
                    WarehouseName = warehouseName,
                    ItemAmount = 0
                };
                return true;
            }
        }
        public static bool Update(int itemCode, string warehouseName,int amount,char op)
        {
            using(var context=new AppDbContext())
            {
                var item = context.ItemWarehouses.FirstOrDefault(i => i.ItemCode == itemCode&&i.WarehouseName == warehouseName);
                if (item == null) return false;
                if (op == '+') item.ItemAmount += amount;
                else item.ItemAmount -= amount;
                context.SaveChanges();
                return true;
            }
        }
        public static List<ItemWarehouse> SelectItemBasedOnWarehouses(List<string> warehouseNames)
        {
            using (var context = new AppDbContext())
            {
                var items = context.ItemWarehouses.Where(i => warehouseNames.Contains(i.WarehouseName)).ToList();
                return items;
            }
        }
    }
}
