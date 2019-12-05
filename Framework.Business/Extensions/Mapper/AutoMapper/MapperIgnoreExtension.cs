using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Framework.Business.Extensions.Mapper.AutoMapper
{
    public static class MapperIgnoreExtension
    {
        /*
         * Destination parametresi olarak geçilen objet  içersinde virtual property varsa ignore etmek için oluşturuldu
         */
        public static IMappingExpression<TSource, TDestination> IgnoreVirtualPropertyDestination<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                p.GetGetMethod().IsVirtual))
            {
                expression.ForMember(property.Name, options => options.Ignore());

            }
            return expression;
        }
        /*
         * Source parametresi olarak geçilen objet  içersinde virtual property varsa ignore etmek için oluşturuldu
         */
        public static IMappingExpression<TSource, TDestination> IgnoreVirtualPropertySource<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                p.GetGetMethod().IsVirtual))
            {
                expression.ForSourceMember(property.Name, options => options.Ignore());

            }
            return expression;
        }
    }
}

