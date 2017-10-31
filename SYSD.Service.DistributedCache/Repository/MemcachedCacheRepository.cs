using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.Repository
{
    internal class MemcachedCacheRepository : BaseCacheRepository, ICacheRepository
    {
        private MemcachedClient memClient;
        internal MemcachedCacheRepository(string _conn) : base(_conn)
        {
        }
        private MemcachedClient MemcachedDb()
        {
            if (memClient == null)
            {
                lock (typeof(MemcachedClient))
                {
                    if (memClient == null)
                    {
                        this.Open();
                    }
                }
            }
            return memClient;
        }
        public override T GetValue<T>(string key)
        {
            try
            {
                var value = memClient.Get(key).ToString();
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool SetValue(string key, object value, TimeSpan expiretime)
        {
            try
            {
                var valueStr = JsonConvert.SerializeObject(value);
                
                return memClient.Store(Enyim.Caching.Memcached.StoreMode.Set, key, valueStr, DateTime.Now.AddTicks(expiretime.Ticks)); ;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Delete(string key)
        {
            memClient.Remove(key);
            return true;
        }

        public override void Open()
        {
            //初始化缓存  
            MemcachedClientConfiguration memConfig = new MemcachedClientConfiguration();
            IPAddress newaddress = IPAddress.Parse(""); //host  
            IPEndPoint ipEndPoint = new IPEndPoint(newaddress, 11211);
            // 配置文件 - ip  
            memConfig.Servers.Add(ipEndPoint);
            // 配置文件 - 协议  
            memConfig.Protocol = MemcachedProtocol.Binary;
            // 配置文件-权限，如果使用了免密码功能，则无需设置userName和password  
            memConfig.Authentication.Type = typeof(PlainTextAuthenticator);
            memConfig.Authentication.Parameters["zone"] = "";
            memConfig.Authentication.Parameters["userName"] = "XXXXXXXXXXXXXXXXX";
            memConfig.Authentication.Parameters["password"] = "XXXXXXXXXX";
            //下面请根据实例的最大连接数进行设置  
            memConfig.SocketPool.MinPoolSize = 5;
            memConfig.SocketPool.MaxPoolSize = 200;
            memClient = new MemcachedClient(memConfig);
        }
        
        public override void Dispose()
        {
            memClient.Dispose();
            memClient = null;
        }
    }
}
