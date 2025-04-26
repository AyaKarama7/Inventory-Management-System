using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class CustomerBusiness
    {
        public static bool Insert(string Name, string Phone, string Mobile, string Fax, string Mail, string Website)
        {
            using (var context = new AppDbContext())
            {
                var customer = new Customer
                {
                    CustomerName = Name,
                    CustomerPhone = Phone,
                    CustomerMobile = Mobile,
                    CustomerFax = Fax,
                    CustomerEmail = Mail,
                    CustomerWebsite = Website
                };
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
        }
        public static List<Customer> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                var customers = context.Customers.ToList();
                return customers;
            }
        }
        public static bool Update(string Name, string Phone, string Mobile, string Fax, string Mail, string Website)
        {
            using (var context = new AppDbContext())
            {
                var supplier = context.Customers.FirstOrDefault(s => s.CustomerName == Name);
                if (supplier == null) return false;
                supplier.CustomerName = Name;
                supplier.CustomerPhone = Phone;
                supplier.CustomerMobile = Mobile;
                supplier.CustomerFax = Fax;
                supplier.CustomerEmail = Mail;
                supplier.CustomerWebsite = Website;
                context.SaveChanges();
                return true;
            }
        }
    }
}
