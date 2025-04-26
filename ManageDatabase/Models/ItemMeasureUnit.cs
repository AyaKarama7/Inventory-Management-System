using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class ItemMeasureUnit
    {
        public int ItemCode { get; set; }
        public string? Unit { get; set; }
        public Item? Item { get; set; }
    }
}
