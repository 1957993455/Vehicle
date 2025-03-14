using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
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
    typeof(AppDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
    [DependsOn(typeof(VehicleManagementApplicationContractsModule))]
    [DependsOn(typeof(OrderManagementApplicationContractsModule))]
    [DependsOn(typeof(PaymentManagementApplicationContractsModule))]
    [DependsOn(typeof(AuditLogManagementApplicationContractsModule))]
    [DependsOn(typeof(FileManagementApplicationContractsModule))]
    public class AppApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AppDtoExtensions.Configure();
    }
}
