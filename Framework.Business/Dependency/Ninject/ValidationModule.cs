using FluentValidation;
using Framework.Business.ValidationRules.FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.Dependency.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator>().To<ProductValidator>().InSingletonScope();
        }
    }
}
