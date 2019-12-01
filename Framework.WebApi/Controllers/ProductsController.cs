using Framework.Business.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Products;
using System.Collections.Generic;
using System.Web.Http;

namespace Framework.WebApi.Controllers
{
    // ReSharper disable once InvalidXmlDocComment
    /// <summary>
    /// Dependecy injection WebApi implementasyonu için
    /// WebApiContrib.IoC.Ninject
    /// Ninject.MVC5 paketlerinin kurulumları gereklidir.
    // ReSharper disable once CommentTypo
    /// Buna bağlı olarak kurulan paketlerden olan WebAActivatorEx paket  App-Start içine Ninject.Web.Common class'ı oluşturur web dependency injection bağımlılıkları burada tanımlanır.
    /// </summary>
    // ReSharper disable once HollowTypeName
    public class ProductsController : ApiController
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public List<ProductDto> GetList()
        {
            return _productService.GetList();
        }

        public string Add(string id)
        {
            return "";
        }
    }
}
