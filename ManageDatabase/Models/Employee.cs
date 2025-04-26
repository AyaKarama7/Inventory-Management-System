using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
