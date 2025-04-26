using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemMeasureUnit> ItemMeasureUnits { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SupplingPermission> SupplingPermissions { get; set; }
        public DbSet<SupplingPermissionDetails> SupplingPermissionDetails { get; set; }
        public DbSet<ConsumptionPermission> ConsumptionPermissions { get; set; }
        public DbSet<ConsumptionPermissionDetails> ConsumptionPermissionDetails { get; set; }
        public DbSet<StockTransform> StockTransforms { get; set; }
        public DbSet<StockTransformDetails> StockTransformDetails { get; set; }
        public DbSet<ItemWarehouse> ItemWarehouses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-55EAORK\\SQLEXPRESS;" +
            "Initial Catalog=WarehouseDB;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemWarehouse>().HasKey(i => new { i.ItemCode, i.WarehouseName });
            modelBuilder.Entity<ItemMeasureUnit>().HasKey(c => new { c.ItemCode, c.Unit });
            modelBuilder.Entity<ConsumptionPermissionDetails>()
                .HasKey(C => new { C.ConsumptionID, C.ItemCode });
            modelBuilder.Entity<StockTransformDetails>()
                .HasKey(C => new { C.TransformID, C.ItemCode });
            modelBuilder.Entity<SupplingPermissionDetails>()
                .HasKey(C => new { C.SupplingID, C.ItemCode });
            modelBuilder.Entity<ConsumptionPermission>().HasOne(x => x.Warehouse)
                .WithMany(y => y.Permissions).HasForeignKey(y => y.WarehouseName)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ConsumptionPermission>().HasOne(x => x.Customer)
                .WithMany(y => y.Permissions).HasForeignKey(y => y.CustomerName)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ConsumptionPermissionDetails>().HasOne(x => x.ConsumptionPermission)
                .WithMany(y => y.PermissionDetails).HasForeignKey(y => y.ConsumptionID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ConsumptionPermissionDetails>().HasOne(x => x.Item)
                .WithMany(y => y.PermissionDetails).HasForeignKey(y => y.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ItemWarehouse>().HasOne(x => x.Warehouse)
                .WithMany(y => y.ItemWarehouses).HasForeignKey(y => y.WarehouseName)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ItemWarehouse>().HasOne(x => x.Item)
                .WithMany(y => y.ItemWarehouses).HasForeignKey(y => y.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ItemMeasureUnit>().HasOne(x => x.Item)
                .WithMany(y => y.ItemMeasureUnits).HasForeignKey(y => y.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StockTransform>().HasOne(x => x.FWarehouse)
                .WithMany(y => y.From).HasForeignKey(y => y.FromWarehouse)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StockTransform>().HasOne(x => x.TWarehouse)
                .WithMany(y => y.To).HasForeignKey(y => y.ToWarehouse)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StockTransform>().HasOne(x => x.Supplier)
                .WithMany(y => y.Transforms).HasForeignKey(y => y.SupplierName)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StockTransformDetails>().HasOne(x => x.StockTransform)
                .WithMany(y => y.StockTransformDetails).HasForeignKey(y => y.TransformID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StockTransformDetails>().HasOne(x => x.Item)
                .WithMany(y => y.StockTransformDetails).HasForeignKey(y => y.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SupplingPermission>().HasOne(x => x.Warehouse)
                .WithMany(y => y.SupplingPermissions).HasForeignKey(y => y.WarehouseName)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SupplingPermission>().HasOne(x => x.Supplier)
                .WithMany(y => y.SupplingPermissions).HasForeignKey(y => y.SupplierName)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SupplingPermissionDetails>().HasOne(x => x.SupplingPermission)
                .WithMany(y => y.SupplingPermissionDetails).HasForeignKey(y => y.SupplingID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SupplingPermissionDetails>().HasOne(x => x.Item)
                .WithMany(y => y.SupplingPermissionDetails).HasForeignKey(y => y.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Warehouse>().HasOne(x => x.Employee)
                .WithOne(y => y.Warehouse).HasForeignKey<Warehouse>(y => y.WarehouseMangerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
