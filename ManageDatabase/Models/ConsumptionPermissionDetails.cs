using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class ConsumptionPermissionDetails
    {
        public int? ConsumptionID { get; set; }
        public int? ItemCode { get; set; }
        public int ItemAmount { get; set; }
        [IgnoreDataMember]
        public ConsumptionPermission? ConsumptionPermission { get; set; }
        [IgnoreDataMember]
        public Item? Item { get; set; }
    }
}
