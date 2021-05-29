using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string ShipperMethod { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("BillingAddress")]
        public int BillingAddressId { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public DateTime shipper_date { get; set; }
    }
   
   
}
