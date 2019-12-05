using FluentValidation;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Products>
    {
        /*
         * Ürün modeli doğrulama kurallarını belirledik. İhtiyaca göre geliştirilebilir.
         */
        public ProductValidator()
        {
            RuleFor(product => product.ProductName).Length(2, 50).WithMessage("Ürün ismi 2 ile 50 karakter arası olmalıdır");
            RuleFor(product => product.CategoryID).NotEmpty().WithMessage("Kategori zorunlu alan");
            RuleFor(product => product.ProductName).NotEmpty().WithMessage("Ürün ismi zorunlu alan");
            RuleFor(product => product.UnitPrice).GreaterThan(0).WithMessage("Fiyat alanı 0 dan büyük olmalı");
        }
    }
}
