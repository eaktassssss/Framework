using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Framework.Core.CrossCuttingConcerns.Security
{
    public class AuthenticationHelper
    {
        public static void CreateAuthenticationCookie
        (Guid id, string userName, string email, DateTime expiration, string[] roles, bool remember,
            string firstName, string lastName)
        {
            /*
             *Yeni bir ticket  oluşturma işlemini yapıyoruz
             */
            var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, remember,
                CreateUserDataFormatText(email, roles, firstName, lastName, id));
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket));
        }
        /*
         * FormsAuthenticationTicket parametrelerinden userData kısmına göndereceğimiz extra dataları belli bir formatta çevirme işlemi
         * yapıyoruz. Daha sonra bu formatlı datayı okuyup işlemlerimizi yapacağız.
         */
        public static string CreateUserDataFormatText(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            var builder = new StringBuilder();
            builder.Append(email);
            builder.Append("|");
            for(int i = 0;i < roles.Length;i++)
            {
                builder.Append(roles[i]);
                if(i < roles.Length - 1)
                {
                    builder.Append(",");
                }
            }
            builder.Append("|");
            builder.Append(firstName);
            builder.Append("|");
            builder.Append(lastName);
            builder.Append("|");
            builder.Append(id);
            return builder.ToString();
        }
    }
}
