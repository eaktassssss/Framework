using AutoMapper;
using Framework.Business.Dependency.Ninject;
using Framework.Business.Mapping.AutoMapper;
using Framework.Core.CrossCuttingConcerns.Security;
using Framework.Core.Utilities.Mvc.Infrastructure;
using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
 

namespace Framework.WebMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfiguration.Configure();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new NinjectBindModule()));
          
        }
        /*
         * AutoMapper  Asp.Net Mvc Konfigürasyonu
         */
        public class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(config => config.AddProfile(new AutoMapperProfile()));
            }
        }
        /*
         * Burada Init medtodu ile PostAuthenticateRequest event'ini yakalýyoruz(Handle ediyoruz)
         * Gelen bütün requestlerde burada ilk AuthenticationTicket iþlemlerini yapýyor olacaðýz
         */
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
        }
        /*
         * Burada cookie bilgilerine ulaþýp o cookie  bilgilerini kullanýcaz
         */
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                /*
            *Cookie deðerini okuyoruz.
            */
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie == null)
                {
                    return;
                }
                /*
                 * FormsAuthentication.Encrypt() þifreleyip oluþturduðumuz ticket'ýn deðerini alýyoruz
                 */
                var encrypt = cookie.Value;
                if (String.IsNullOrEmpty(encrypt))
                {
                    return;
                }
                /*
                 * Eðer cookie varsa ve  þifreli data boþ deðilse þifreli ticket deðerini tekrardan çözümlüyoruz
                 */
                var ticket = FormsAuthentication.Decrypt(encrypt);
                /*
                 * Çözümlerken kendi yazdýðýmýz TicketToIdentity metodunu kullanarak þifreli veriyi çözüp Identity nesnesine
                 * çeviriyoruz
                 */
                var identity = CookieToIdentityObjectCast.TicketToIdentity(ticket);
                /*
                 * Artýk bir  identity nesnemiz var ve  bunu principal'a ekliyoruz
                 */
                var princibal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = princibal;
                Thread.CurrentPrincipal = princibal;
            }
            catch
            {
            }

        }
    }
}
