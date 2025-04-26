using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ItemBusiness
    {
        public static bool Insert(string itemName)
        {
            using (var context = new AppDbContext())
            {
                var item = new Item
                {
                    ItemName = itemName,
                    
                };
                context.Items.Add(item);
                context.SaveChanges();
                return true;
            }
        }
        public static List<Item> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                var items = context.Items.ToList();
                return items;
            }
        }
        public static bool Update(int itemCode, string itemName)
        {
            using (var context = new AppDbContext())
            {
                var item = context.Items.FirstOrDefault(i => i.ItemCode == itemCode);
                if (item == null) return false;
                item.ItemName = itemName;
                context.SaveChanges();
                return true;
            }
        }
        
    }
}
