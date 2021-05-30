using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class BillingAddressModelView
    {
        public int ID { get; set; }
        public string street { get; set; }
        public string Phone { get; set; }
        public string ApplicationUserIdentity_Id { get; set; }
        public string ShipperName { get; set; }
        public int PaymentID { get; set; }
    }
}
