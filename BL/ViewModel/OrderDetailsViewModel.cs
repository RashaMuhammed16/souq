using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
     public class OrderDetailsViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Total Price")]
        public double productTotal { get; set; }
        
       
       
        public int productQuantity { get; set; }
        public int ProductID { get; set; }
        public int orderID { get; set; }
       
        public string productName { get; set; }
    }
}
