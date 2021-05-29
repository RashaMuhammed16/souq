using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    

[Table("Product")]
public class Product
{

    public int ID { get; set; }
    [Required]
    [MinLength(5)]
    //[RegularExpression("[a-zA-Z]{5,}", ErrorMessage = "Name must be only characters and more that 5")]
    public string Name { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid price")]
    public double Price { get; set; } //make it double instead of nullable

    [Required]
    [MinLength(10)]
    public string Description { get; set; }

    [Required]
    [Range(5, int.MaxValue, ErrorMessage = "Discout Must be more than 5")]
    public double Discount { get; set; }

    public string Image { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Quantity Must be more than 1")]
    public int Quantity { get; set; }

    


    [ForeignKey("Sub_Catogery")]
    public int Sub_CatogeryId { get; set; }
    public Sub_Catogery Sub_Catogery { get; set; }


        public List<Model>Models { get; set; } = new List<Model>();
        public List<ProductWishList> Wishlists { get; set; } = new List<ProductWishList>();

        public List<OrderDetails> orderDetail { get; set; } = new List<OrderDetails>();
    public List<Rate> Rates { get; set; } = new List<Rate>();


}
}
