using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        /*
         * TransactionAspect testi için yazıldı
         */
        void TransactionTestMethod(Product product1, Product product2);
    }
}
