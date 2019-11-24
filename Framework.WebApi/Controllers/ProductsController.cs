using Framework.Business.Abstract;
using Framework.DataAccess.Context;
using System.Collections.Generic;
using System.Web.Http;

namespace Framework.WebApi.Controllers
{
    /// <summary>
    /// Dependecy injection WebApi implementasyonu için
    /// WebApiContrib.IoC.Ninject
    /// Ninject.MVC5 paketlerinin kurulumları gereklidir.
    /// Buna bağlı olarak kurulan paketlerden olan WebAActivatorEx paket  App-Start içine Ninject.Web.Common class'ı oluşturur web dependency injection bağımlılıkları burada tanımlanır.
    /// </summary>
    public class ProductsController: ApiController
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public List<Product> GetList()
        {
            return _productService.GetList();
        }
    }
}
