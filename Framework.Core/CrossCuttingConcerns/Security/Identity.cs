using System;
using System.Security.Principal;

namespace Framework.Core.CrossCuttingConcerns.Security
{
    public class Identity: IIdentity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
