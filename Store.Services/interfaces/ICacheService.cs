using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface ICacheService
    {
        public Task setCacheKeyAsync(string key, object response, TimeSpan expire);
        public Task<string> getCacheAsync(string key);
    }
}
