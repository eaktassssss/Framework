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
    public class CacheAspect : MethodInterceptionAspect
    {
        Type _cacheType; int _time;
        ICacheManager _cacheManager;
        public CacheAspect(Type cacheType, int time=60)
        {
            _cacheType = cacheType;
            _time = time;
        }
        /// <summary>
        /// Burada gelen CacheManager'dan nesne üretimi yapıyoruz.
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
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            /*Framework.Business.Concrete.ProductManager.GetProductList,
             * Key oluşturma Namespace, Class ismi ve method ismini alıyoruz
             */
            var metodName = string.Format("{0}.{1}.{2},", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name, args.Method.Name);

            /*
             * Cache'e alınıcak methodun parametrelerini bir liste halinde alıyoruz
             */
            var arguments = args.Arguments.ToList();
            /*
             *Son olarak  string.Format ile Namespace, Class ismi ve method isminden oluşturduğumuz string ifade ile 
             * Method parametrelerini string.Join ile select edip  key oluşturma işlemini bitiriyoruz.
             */
            var key = string.Format("{0}({1})", metodName, string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

            /*
             * _cacheManager.IsAdd(key) ile  bu key cache'de var mı yada bu key'e ait  cache data varmı bakıyoruz 
             * Varsa  _cacheManager.Get<object>(key) ile  o datayı çekiyoruz.
             */
            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            else
            {
                /*
                 * Burada args.Proceed(); ile  ilerle diyoruz ve  daha sonra businnes içindeki  method  çalışıtırılıp  daha sonra cache  ekleniyor.
                 * Aslında  args.Proceed();  gidip  business içindeki methoda ilerlememizi  sağlıyor  ve  daha sonra cache  ekleme  işlemini  add metodu yapıyor
                 */
                args.Proceed();
                _cacheManager.Add(key, args.ReturnValue, _time);
              
            }
          
            /*
             * Eğer  Cache içinde Yok ise  ekliyoruz
             */
           
        }
    }
}
