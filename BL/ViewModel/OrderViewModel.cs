using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.ViewModel
{
  public  class OrderViewModel
    {

        public int OrderId { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        public int paymentId { get; set; }
        public int shipperId { get; set; }
        [DataType(DataType.DateTime)]
        public string Orderdate { get; set; }
        public string ApplicationUserIdentity_Id { get; set; }
        public virtual ApplicationUserIdentity appUser { get; set; }
    }
}

