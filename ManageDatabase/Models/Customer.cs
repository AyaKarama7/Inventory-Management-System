using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class Customer
    {
        [Key]
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerFax { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerWebsite { get; set; }
        public string? CustomerMobile { get; set; }
        public List<ConsumptionPermission>? Permissions { get; set; }
    }
}
