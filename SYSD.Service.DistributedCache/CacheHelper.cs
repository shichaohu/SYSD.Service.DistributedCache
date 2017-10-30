using SYSD.Service.DistributedCache.Factory;
using SYSD.Service.DistributedCache.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache
{
    public class CacheHelper:IDisposable
    {
        private CacheFactory cacheFactory = null;
        private string _conn;
        public CacheHelper(CacheTypeEnum type)
        {
            switch (type)
            {
                case CacheTypeEnum.Redis:
                    cacheFactory = new RedisCacheFactory();
                    _conn = ConfigurationManager.AppSettings["RedisConnString"];
                    break;
                default:
                    cacheFactory = null;
                    break;

            }
        }
        public T GetValue<T>(string key) where T : class
        {
            using (var cache = cacheFactory.GetCache(_conn))
            {
                return cache.GetValue<T>(key);
            }
        }

        public bool SetValue(string key, object value, TimeSpan expiretime)
        {
            try
            {
                using (var cache = cacheFactory.GetCache(_conn))
                {
                    return cache.SetValue(key, value, expiretime);
                }
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        
        public void Dispose()
        {
            cacheFactory = null;
        }
    }
}
