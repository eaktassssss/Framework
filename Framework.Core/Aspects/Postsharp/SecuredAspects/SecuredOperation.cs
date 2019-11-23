using PostSharp.Aspects;
using System;
using System.Linq;
using System.Security;
using System.Threading;

namespace Framework.Core.Aspects.Postsharp.SecuredAspects
{
    [Serializable]
    public class SecuredOperation: OnMethodBoundaryAspect
    {
        public string Roles { get; set; } = "Editör";
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',').ToArray();
            bool isAuthorized = false;
            for(int i = 0;i < roles.Length;i++)
            {
                if(Thread.CurrentPrincipal.IsInRole((roles[i])))
                {
                    isAuthorized = true;
                }
            }
            if(isAuthorized == false)
            {
                throw new SecurityException("Bu işlem için yetki tanımınız bulunmamaktadır.");
            }
        }
    }
}
 