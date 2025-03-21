using AuditLogManagement;
using FileManagement.Application.Contracts;
using Vehicle.App.Domain.Shared;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Vehicle.App.Application.Contracts;

[DependsOn(
    typeof(AppDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
[DependsOn(typeof(AuditLogManagementApplicationContractsModule))]
[DependsOn(typeof(FileManagementApplicationContractsModule))]
public class AppApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AppDtoExtensions.Configure();
    }
}
