using SYSD.Service.DistributedCache.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.Factory
{
    internal class MemcachedCacheFactory: CacheFactory
    {
        protected internal override ICacheRepository GetCache(string _conn)
        {
            return new MemcachedCacheRepository(_conn);
        }
    }
}
