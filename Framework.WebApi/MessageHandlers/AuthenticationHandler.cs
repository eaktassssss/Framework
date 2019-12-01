using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Framework.WebApi.MessageHandlers
{
    public class AuthenticationHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            /*
             * İlk olarak token değerini alıyoruz
             */
            var token = request.Headers.GetValues("Authorization").FirstOrDefault();
            if (token !=null)
            {
                /*
                 * FromBase64String token bir byte dizisi şeklinde alınır
                 */
                byte[] data = Convert.FromBase64String(token);
                /*
                *  Daha sonra Encoding.UTF8.GetString ile bu byte dizisi  bir string'e çevrilir
                */
                string decodedString = Encoding.UTF8.GetString(data);

                /*
                 * Son olarak bu string içersinden username ve password almak için split edilir
                 */
                string[] tokenValues = decodedString.Split(':');

                if (tokenValues [0]=="eaktas" && tokenValues[1]== "123456")
                {
                    /*
                     * Kullanıcı bilgileri doğru ise kullanıcı sisteme login edilir
                     */
                    IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), new[] { "Admin" });
                    HttpContext.Current.User = principal;
                    Thread.CurrentPrincipal = principal;
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}