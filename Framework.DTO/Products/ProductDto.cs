using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO.Categories;

namespace Framework.DTO.Products
{
    public class ProductDto
    {
        
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public int  UnitsInStock{ get; set; }
    }
}
