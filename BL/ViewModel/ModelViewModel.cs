using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
   public class ModelViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
    }
}
