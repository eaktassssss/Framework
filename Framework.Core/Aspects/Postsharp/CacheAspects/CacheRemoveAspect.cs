using Framework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        string _pattern; Type _cacheType; ICacheManager _cacheManager;

        /*
         * CacheType'a göre silme işlemi yapar
         */
        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }
        /*
         * CacheType ve gönderilen pattern'e göre silme işlemi yapar
         */
        public CacheRemoveAspect(string pattern, Type cacheType)
        {
            _pattern = pattern; _cacheType = cacheType;
        }
        /// <summary>
        /// RuntimeInitializer ile  bir  nesne üretimi yapıyoruz ve  bunu yaparken CacheManager Tipimizi kontrol ediyoruz
        /// </summary>
        /// <param name="method"></param>
        public override void RuntimeInitialize(MethodBase method)
        {
            /*
             * Gönderilen cacheType bir ICacheManager türünde değilse 
             */
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }
        /*
         * Cache mantığımız add , updte vs operasyonlarımız başarılı olduğu taktirde  
         * ve CacheRemoveAspect çağırıldığı anda o namespacedeki o classı ilgilendiren 
         * bütün cacheleri siler
         */
        public override void OnSuccess(MethodExecutionArgs args)
        {
            if (String.IsNullOrEmpty(_pattern))
            {
                this._pattern = string.Format("{0}.{1}*", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name);
                _cacheManager.RemoveByPattern(this._pattern);
            }
            else
                _cacheManager.RemoveByPattern(this._pattern);
        }
    }
}
