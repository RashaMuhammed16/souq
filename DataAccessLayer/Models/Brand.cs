using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Brand
    {
        public int  ID { get; set; }
        public string Name  { get; set; }
        public List<Model> Models { get; set; } = new List<Model>();
    }
}
