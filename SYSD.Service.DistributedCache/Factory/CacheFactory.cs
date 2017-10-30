using SYSD.Service.DistributedCache.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.Factory
{
    internal abstract class CacheFactory
    {
        protected internal abstract ICacheRepository GetCache(string _conn);
    }
}
