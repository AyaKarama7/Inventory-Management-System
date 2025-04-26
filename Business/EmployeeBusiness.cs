using ManageDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class EmployeeBusiness
    {
        public static bool Insert(string Name)
        {
            using (var context = new AppDbContext())
            {
                var employee = new Employee
                {
                    EmployeeName=Name,
                };
                context.Employees.Add(employee);
                context.SaveChanges();
                return true;
            }
        }
    }
}
