using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.Repository
{
    internal abstract  class BaseCacheRepository:ICacheRepository
    {
        protected string _conn;
        protected ICacheRepository cacheRepository;
        protected static readonly object cacheLocker = new object();
        protected BaseCacheRepository(string _conn)
        {
            this._conn = _conn;
        }
        public virtual T GetValue<T>(string key) where T : class
        {
            return default(T);
        }

        public virtual bool SetValue(string key, object value, TimeSpan expiretime)
        {
            return false;
        }

        public virtual bool Delete(string key)
        {
            return false;
        }

        public abstract void Open();
        
        public abstract void Dispose();
    }
}
