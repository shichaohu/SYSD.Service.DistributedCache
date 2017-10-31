using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.CacheConfig
{
    internal class BaseCacheConfig
    {
        internal string Host { set; get; }
        internal string Port { set; get; }
        internal string DbName { set; get; }
        internal string UseName { set; get; }
        internal string PassWord { set; get; }

        internal string ConnectString { set; get; }
    }
}
