using Framework.WebApi.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Framework.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
             * Yazmış olduğumuz AuthenticationHandler burada tanıtıyoruz.
             * Artık gelen bütün isteklerde ilk bu handler devreye girecek ve  request üzerinden kontrolleri  yapmamızı sağlayacak
             * mekanizma ayağa kalkmış olucak
             */
            config.MessageHandlers.Add(new AuthenticationHandler());
           
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
