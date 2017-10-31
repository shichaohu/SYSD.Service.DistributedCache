using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.Repository
{
    internal class RedisCacheRepository : BaseCacheRepository, ICacheRepository
    {
        private IConnectionMultiplexer _redisconn = null;
        private IDatabase _redisdb = null;
        private IDatabase RedisDb
        {
            get {
                if (_redisdb == null)
                    this.Open();

                return _redisdb;
            }
        }

        internal RedisCacheRepository(string _conn) : base(_conn)
        {
        }
        public override T GetValue<T>(string key)
        {
            try
            {
                var value = RedisDb.StringGet(key);
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
                return RedisDb.StringSet(key, valueStr, expiretime);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Delete(string key)
        {
            return RedisDb.KeyDelete(key);
        }

        public override void Open()
        {
            if (_redisconn == null)
            {
                _redisconn = ConnectionMultiplexer.Connect(_conn);
            }
            if (_redisdb == null)
            {
                _redisdb = _redisconn.GetDatabase();
            }
        }

        public override void Dispose()
        {
            _redisconn.Close();
            _redisconn.Dispose();
            _redisdb = null;
        }
    }
}
