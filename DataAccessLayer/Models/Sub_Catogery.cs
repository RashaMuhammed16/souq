using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
     public class Sub_Catogery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }
        [ForeignKey("Category")]
        public int CatogeryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
