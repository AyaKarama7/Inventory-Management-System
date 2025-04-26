using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ConsumptionPermissionBusiness
    {
        public static bool Insert(DateTime permissionDate, string warehouseName, string customerName)
        {
            using (var context = new AppDbContext())
            {
                var consumptionPermission = new ConsumptionPermission
                {
                    WarehouseName = warehouseName,
                    PermissionDate = permissionDate,
                    CustomerName = customerName
                };
                context.ConsumptionPermissions.Add(consumptionPermission);
                context.SaveChanges();
                return true;
            }
        }
        public static List<ConsumptionPermission> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                var consumptionPermissions = context.ConsumptionPermissions.ToList();
                return consumptionPermissions;
            }
        }
        public static bool Update(int consumptionId, DateTime permissionDate, string warehouseName, string customerName)
        {
            using (var context = new AppDbContext())
            {
                var consumptionPermission = context.ConsumptionPermissions.FirstOrDefault(s => s.ConsumptionID == consumptionId);
                if (consumptionPermission == null) return false;
                consumptionPermission.CustomerName = customerName;
                consumptionPermission.WarehouseName = warehouseName;
                consumptionPermission.PermissionDate = permissionDate;
                context.SaveChanges();
                return true;
            }
        }
    }
}
