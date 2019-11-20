using FluentValidation;
using FluentValidation.Results;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class ValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            /* override void OnEntry
             * OnEntry metodunu override ediyoruz.
             * OnEntry:metoda girdiği zaman çalışmasını sağlar
             * Validate işlemi için bir adet Validator ve object'e ihtiyacımız var
             */
            /*
             * Dışarıdan alınan _validatorType nesnesi validator'ı temsil eder bundan öncelikle bir nesne üretiyoruz
             */
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // (ProductValidator)
            /*
             * Daha sonra validate edilicek nesneyi  öğrenmemiz gerekiyor onun için BaseType.GetGenericArguments()[0] ile
             * Validator'ın baseType'ına ulaşır GetGenericArguments ile verilmiş olan argümanı(parametreyi alıyoruz)
             * [0] ifadesi  ilk argümanı verir.
             */
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // BaseType =AbstractValidator< Argüman=Product>

            /*
             * Şimdi  son olarak argümanı bulduk yanş sınıfı ona ait entity nesnelerini tek tek gezip validate etmemiz gerekiyor
             */
            var entities = args.Arguments.Where(t=> t.GetType()==entityType);
            foreach (PropertyInfo item in entities)
            {
                validator.Validate(item);
            }
        }
    }
}
