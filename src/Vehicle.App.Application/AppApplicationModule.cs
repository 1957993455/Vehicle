using AuditLogManagement;
using Vehicle.App.Application.Contracts;
using Vehicle.App.Domain;
using Vehicle.App.FileManagement.Application;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Vehicle.App.Application;

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
