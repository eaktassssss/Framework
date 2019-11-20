using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private ObjectCache Cache
        {
            get { return MemoryCache.Default;}
        }
        public void Add(string key, object data, int time=60)
        {
            if (data==null)
            {
                return;
            }
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(time),
            };
            Cache.Add(new CacheItem(key,data),policy);
           /*
            * AbsoluteExpiration : data cache'de ne kadar  kalıcak onu belirler
            */
        }

        public void Clear()
        {
            /*
             * Tüm Cacheleri siler
             */
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            /*
             * Cache'deki datayı getirir
             */
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            /*
             * Cache'de var mı
             */
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            /*
             * Key değerine göre cache siler
             */
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern,RegexOptions.Singleline | RegexOptions.Compiled |RegexOptions.IgnoreCase);
            var keyToRemove = Cache.Where(d=> regex.IsMatch(d.Key)).Select(d=> d.Key).ToList();
            foreach (var key in keyToRemove)
            {
                Remove(key);
            }
        }
    }
}
