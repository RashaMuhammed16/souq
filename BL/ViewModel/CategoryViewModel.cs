using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace BL.ViewModel
{
   public class CategoryViewModel
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryImage { get; set; }
    }
}
