using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.Repository
{
    internal class MongoDBCacheRepository : BaseCacheRepository, ICacheRepository
    {
        private IMongoClient server = null;
        private IMongoDatabase db = null;
        private IMongoDatabase Db
        {
            get
            {
                if (server == null)
                    this.Open();

                return db;
            }
        }

        internal MongoDBCacheRepository(string _conn) : base(_conn)
        {
        }
        public override T GetValue<T>(string key)
        {
            try
            {
                var value = "";
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Delete(string key)
        {
            return true;
        }

        public override void Open()
        {
            if (server == null)
            {
                server = new MongoClient("");//MongodbHost
            }
            db = server.GetDatabase("");//MongodbName
        }

        public override void Dispose()
        {
            db.DropCollection("");//MongodbName
            db = null;
        }
    }
}
