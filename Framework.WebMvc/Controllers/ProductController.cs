using Framework.Business.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Products;
using System.Linq;
using System.Web.Mvc;

namespace Framework.WebMvc.Controllers
{
    public class ProductController: Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var products = _productService.GetList().AsEnumerable();
            return View(products.ToList());
        }
        [HttpPost]
        public ActionResult Add(ProductDto product)
        {

            _productService.Add(product);
           
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}