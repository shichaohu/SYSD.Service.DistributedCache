using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache
{
    public enum CacheTypeEnum
    {
        /// <summary>
        /// Redis 
        /// </summary>
        Redis,
        /// <summary>
        /// SSDB
        /// </summary>
        SSDB,
        /// <summary>
        /// Memcached
        /// </summary>
        Memcached,
        /// <summary>
        /// MongoDB
        /// </summary>
        MongoDB,
        /// <summary>
        /// SQLServer内存表
        /// </summary>
        SqlServer,
        /// <summary>
        /// 阿里云的缓存服务OCS
        /// </summary>
        AliyunMemcached,
    }
}
