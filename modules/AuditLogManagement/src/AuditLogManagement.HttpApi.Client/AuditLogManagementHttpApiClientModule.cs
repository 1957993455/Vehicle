using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AuditLogManagement;

[DependsOn(
    typeof(AuditLogManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AuditLogManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AuditLogManagementApplicationContractsModule).Assembly,
            AuditLogManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AuditLogManagementHttpApiClientModule>();
        });

    }
}
