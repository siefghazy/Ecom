using StackExchange.Redis;
using Store.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Store.Services.services
{
    public class CacheServices : ICacheService
    {
        private readonly IDatabase _redis;

        public CacheServices(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }
        public async Task<string> getCacheAsync(string key)
        {
            var response =await _redis.StringGetAsync(key);
            if (response.IsNullOrEmpty)
            {
                return null;
            }
            return response.ToString();
        }

        public async Task setCacheKeyAsync(string key, object response, TimeSpan expire)
        {
            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
           await _redis.StringSetAsync(key, JsonSerializer.Serialize(response, options), expire);

        }
    }
}
