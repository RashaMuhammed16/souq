using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
     public class OrderDetails
    {
        public int ID { get; set; }

        public double Total { get; set; }
        public  String Date { get; set; }
        
       

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        [ForeignKey("Order")]
        public int orderID { get; set; }

        public Order Order { get; set; }

    }
}
