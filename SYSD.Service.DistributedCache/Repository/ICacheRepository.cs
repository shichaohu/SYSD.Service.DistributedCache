using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSD.Service.DistributedCache.Repository
{
    internal interface ICacheRepository:IDisposable
    {
        T GetValue<T>(string key) where T : class;

        bool SetValue(string key, object value, TimeSpan expiretime);

        bool Delete(string key);

        void Open();
    }
}
