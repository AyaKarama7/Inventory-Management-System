using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class SupplingPermissionBusiness
    {
        public static bool Insert(DateTime permissionDate, string warehouseName, string supplierName)
        {
            using (var context = new AppDbContext())
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.SupplierName == supplierName);
                var warehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseName == warehouseName);
                var supplingPermission  = new SupplingPermission
                {
                    WarehouseName = warehouse?.WarehouseName,
                    PermissionDate = permissionDate,
                    SupplierName = supplier?.SupplierName,
                };
                context.SupplingPermissions.Add(supplingPermission);
                context.SaveChanges();
                return true;
            }
        }
        public static List<SupplingPermission> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                var supplingPermissions = context.SupplingPermissions.ToList();
                return supplingPermissions;
            }
        }
        public static bool Update(int supplingId,DateTime permissionDate, string warehouseName, string supplierName)
        {
            using (var context = new AppDbContext())
            {
                var supplingPermission = context.SupplingPermissions.FirstOrDefault(s => s.SupplingID == supplingId);
                if (supplingPermission == null) return false;
                supplingPermission.SupplierName = supplierName;
                supplingPermission.WarehouseName = warehouseName;
                supplingPermission.PermissionDate = permissionDate;
                context.SaveChanges();
                return true;
            }
        }
    }
}
