using Microsoft.Extensions.Caching.StackExchangeRedis;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace Vehicle.Cache.Redis;

/// <summary>
/// Redis缓存模块
/// </summary>
[DependsOn(typeof(AbpCachingStackExchangeRedisModule))]
public class VehicleCacheRedisModule:AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<RedisCacheOptions>(options =>
        {
        });
    }
}
