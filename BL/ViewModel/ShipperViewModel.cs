using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class ShipperViewModel
    {
        [Required]
        public int ShipperID { get; set; }
        public string ShipperMethod { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime shipper_date
        {
            get; set;
        }
    }
}
