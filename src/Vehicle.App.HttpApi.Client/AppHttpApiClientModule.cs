using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using VehicleManagement;
using OrderManagement;
using PaymentManagement;
using AuditLogManagement;
using FileManagement;

namespace Vehicle.App;

[DependsOn(
    typeof(AppApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
    [DependsOn(typeof(VehicleManagementHttpApiClientModule))]
    [DependsOn(typeof(OrderManagementHttpApiClientModule))]
    [DependsOn(typeof(PaymentManagementHttpApiClientModule))]
    [DependsOn(typeof(AuditLogManagementHttpApiClientModule))]
    [DependsOn(typeof(FileManagementHttpApiClientModule))]
    public class AppHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AppApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AppHttpApiClientModule>();
        });
    }
}
