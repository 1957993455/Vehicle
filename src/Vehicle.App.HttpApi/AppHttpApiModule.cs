using AuditLogManagement;
using FileManagement;
using Localization.Resources.AbpUi;
using Vehicle.App.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Vehicle.App;

[DependsOn(
   typeof(AppApplicationContractsModule),
   typeof(AbpPermissionManagementHttpApiModule),
   typeof(AbpSettingManagementHttpApiModule),
   typeof(AbpAccountHttpApiModule),
   typeof(AbpIdentityHttpApiModule),
   typeof(AbpTenantManagementHttpApiModule),
   typeof(AbpFeatureManagementHttpApiModule)
   )]
[DependsOn(typeof(AuditLogManagementHttpApiModule))]
[DependsOn(typeof(FileManagementHttpApiModule))]
public class AppHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AppResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
