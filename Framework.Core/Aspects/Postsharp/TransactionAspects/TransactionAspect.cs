using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Framework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionAspect : OnMethodBoundaryAspect
    {
        TransactionScopeOption _transactionScopeOption;
        public TransactionAspect(TransactionScopeOption transactionScopeOption)
        {
            _transactionScopeOption = transactionScopeOption;
        }
        public TransactionAspect()
        {
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            /*
             *Metoda giriliz girilmez bu metod transaction başlatır
             */
            args.MethodExecutionTag = new TransactionScope(_transactionScopeOption);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            /*
             * İşlem başarlı ise  bu metod  çalışır.
             */
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            /*
             * İşlem  sırasında hata oluşursa  transaction Dispose edilir  
             */
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
