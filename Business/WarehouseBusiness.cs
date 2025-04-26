using ManageDatabase;
using ManageDatabase.Models;
using System.Net;
using System;
namespace Business
{
    public static class WarehouseBusiness
    {
        public static bool Insert(string Name,string Address,int Manger)
        {
            using(var context=new AppDbContext())
            {
                var warehouse = new Warehouse 
                {
                    WarehouseName = Name, 
                    WarehouseAddress = Address, 
                    WarehouseMangerId = Manger 
                };
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
                return true;
            }
        }
        public static List<Warehouse> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                var warehouses = context.Warehouses.Select(warehouse => new Warehouse
                {
                    WarehouseName = warehouse.WarehouseName,
                    WarehouseAddress = warehouse.WarehouseAddress,
                    WarehouseMangerId = warehouse.WarehouseMangerId
                }).ToList();
                return warehouses;
            }
        }
        public static bool Update(string Name, string Address, int Manger)
        {
            using (var context = new AppDbContext())
            {
                var warehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseName == Name);
                if (warehouse == null) return false;
                warehouse.WarehouseAddress = Address;
                warehouse.WarehouseMangerId = Manger;
                context.SaveChanges();
                return true;
            }
        }
        public static List<Warehouse> SelectOne(string warehouseName)
        {
            using (var context = new AppDbContext())
            {
                var warehouses = context.Warehouses.Select(warehouse => new Warehouse
                {
                    WarehouseName = warehouse.WarehouseName,
                    WarehouseAddress = warehouse.WarehouseAddress,
                    WarehouseMangerId = warehouse.WarehouseMangerId
                }).Where(w=>w.WarehouseName==warehouseName).ToList();
                return warehouses;
            }
        }
    }
}
