using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using VehicleManagement;
using OrderManagement;
using PaymentManagement;
using AuditLogManagement;
using FileManagement;

namespace Vehicle.App;

[DependsOn(
    typeof(AppDomainModule),
    typeof(AppApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
    [DependsOn(typeof(VehicleManagementApplicationModule))]
    [DependsOn(typeof(OrderManagementApplicationModule))]
    [DependsOn(typeof(PaymentManagementApplicationModule))]
    [DependsOn(typeof(AuditLogManagementApplicationModule))]
    [DependsOn(typeof(FileManagementApplicationModule))]
    public class AppApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AppApplicationModule>();
        });
    }
}
