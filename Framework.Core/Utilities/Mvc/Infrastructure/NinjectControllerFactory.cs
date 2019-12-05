using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;

namespace Framework.Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        /*
         * Default Controller'mızı yazıyoruz 
         */
        private IKernel _kernel;
        public NinjectControllerFactory(INinjectModule module)
        {
            /*
             *Standart kernel  buraya göndereceğimiz module çözümleyecek
             */
            _kernel = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            /*
             * Controller nesnemizi kernel.Get() metodu ile oluşturuyoruz
             */
            if (controllerType==null)
            {
                return null;
            }
           return (IController) _kernel.Get(controllerType);
        }
    }
}
