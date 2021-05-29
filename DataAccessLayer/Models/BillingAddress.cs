using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BillingAddress
    {
        public int ID { get; set; }
        public string street { get; set; }
        public string Phone { get; set; }
        public string ApplicationUserIdentity_Id { get; set; }
        public ApplicationUserIdentity appUser { get; set; }
        public List<Shipper> Shippers { get; set; } = new List<Shipper>();
        public List<Payment>Payment { get; set; } = new List<Payment>();
    }
}
