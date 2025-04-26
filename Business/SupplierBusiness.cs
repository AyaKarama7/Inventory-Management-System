using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class SupplierBusiness
    {
        public static bool Insert(string Name, string Phone, string Mobile,string Fax,string Mail,string Website)
        {
            using (var context = new AppDbContext())
            {
                var supplier = new Supplier
                {
                    SupplierName = Name,
                    SupplierPhone = Phone,
                    SupplierMobile = Mobile,
                    SupplierFax = Fax,
                    SupplierEmail = Mail,
                    SupplierWebsite = Website
                };
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                return true;
            }
        }
        public static List<Supplier>SelectAll()
        {
            using(var context=new AppDbContext())
            {
                var suppliers = context.Suppliers.ToList();
                return suppliers;
            }
        }
        public static bool Update(string Name, string Phone, string Mobile, string Fax, string Mail, string Website)
        {
            using (var context = new AppDbContext())
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.SupplierName == Name);
                if (supplier == null) return false;
                supplier.SupplierName = Name;
                supplier.SupplierPhone = Phone;
                supplier.SupplierMobile = Mobile;
                supplier.SupplierFax = Fax;
                supplier.SupplierEmail = Mail;
                supplier.SupplierWebsite = Website;
                context.SaveChanges();
                return true;
            }
        }
    }
}
