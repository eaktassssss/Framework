using AutoMapper;
using Framework.Business.Mapping.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Framework.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfiguration.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(config => config.AddProfile(new AutoMapperProfile()));
            }
        }
    }
}
