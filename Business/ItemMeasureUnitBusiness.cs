using ManageDatabase.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ItemMeasureUnitBusiness
    {
        public static bool Insert(int itemCode,string unit)
        {
            using(var context=new AppDbContext())
            {
                var itemUnit = new ItemMeasureUnit { ItemCode = itemCode, Unit = unit };
                context.Add(itemUnit);
                context.SaveChanges();
                return true;
            }
        }
        public static List<ItemMeasureUnit> SelectUnitsForItem(List<string> itemCode)
        {
            using(var context = new AppDbContext())
            {
                var items = context.ItemMeasureUnits.
                    Where(i => itemCode.Contains(i.ItemCode.ToString())).ToList();
                return items; ;
            }
        }
       
    }
}
