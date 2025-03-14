using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace OrderManagement;

[DependsOn(
    typeof(OrderManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class OrderManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(OrderManagementApplicationContractsModule).Assembly,
            OrderManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrderManagementHttpApiClientModule>();
        });

    }
}
