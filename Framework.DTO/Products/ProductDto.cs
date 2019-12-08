using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO.Categories;

namespace Framework.DTO.Products
{
    public class ProductDto
    {
        
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Zorunlu alan")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Zorunlu alan")]
        public int  UnitsInStock{ get; set; }
    }
}
