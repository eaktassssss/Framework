using System;
using System.Web.Security;

namespace Framework.Core.CrossCuttingConcerns.Security
{
    public class CookieToIdentityObjectCast
    {
        /*
         * Uygulama boyunca kullanılması için oluşturulan Ticket nesnesini bir Identity nesnesine  çeviriyoruz
         */
        public static Identity TicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = SetId(ticket),
                Name = ticket.Name,
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                AuthenticationType = "Forms",
                IsAuthenticated = true

            };
            return identity;
        }
        // UserData içinden rolleri okuduk
        private static string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            /*
             * UserData datasını | ile  split ediyoruz. 
             */
            string[] data = ticket.UserData.Split('|');
            /*
             *  Dah sonra roller için  data[1].Split(',') rolleri split edip alıyoruz
             */
            string[] roles = data[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }
        // UserData içinden email okuduk
        private static string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }
        // UserData içinden lastname okuduk
        private static string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }
        // UserData içinden firstname okuduk
        private static string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }
        // UserData içinden Id okuduk
        private static Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
