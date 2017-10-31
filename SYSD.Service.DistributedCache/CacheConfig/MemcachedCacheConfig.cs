using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.CacheConfig
{
    internal class MemcachedCacheConfig:BaseCacheConfig
    {
        internal int MaxPoolSize { set; get; }
        internal int MinPoolSize { set; get; }
    }
}
