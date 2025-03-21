using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Caching;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;

namespace Vehicle.Core;

[DependsOn(typeof(AbpEmailingModule), typeof(AbpCachingModule))]
public class VehicleCoreModule : AbpModule
{


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        base.ConfigureServices(context);
    }
}
