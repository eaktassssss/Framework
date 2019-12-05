using Framework.Business.Abstract;
using Framework.Business.Concrete;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Concrete;
using Ninject.Modules;

namespace Framework.Business.Dependency.Ninject
{
    public class NinjectBindModule : NinjectModule
    {
        public override void Load()
        {
            /*
             * Ninject ile Dependency Injecttion yapılandırılması
             * Burada tüm soyut sınıflar  için nesne üretimi yapılacak olan somut  sınıflarımızı tanımlıyoruz.
             */
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<ProductDal>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<CategoryDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<UserDal>().InSingletonScope();
            Bind<IUserRolesService>().To<UserRolesManager>().InSingletonScope();
            Bind<IUserRolesDal>().To<UserRolesDal>().InSingletonScope();
        }
    }
}
