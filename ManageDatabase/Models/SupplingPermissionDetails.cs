using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManageDatabase.Models
{
    public class SupplingPermissionDetails
    {

        public int? SupplingID { get; set; }
        public int? ItemCode { get; set; }
        public int ItemAmount { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [IgnoreDataMember]
        public SupplingPermission? SupplingPermission { get; set; }
        [IgnoreDataMember]
        public Item? Item { get; set; }

    }
}
