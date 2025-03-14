using Localization.Resources.AbpUi;
using AuditLogManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace AuditLogManagement;

[DependsOn(
    typeof(AuditLogManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AuditLogManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AuditLogManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AuditLogManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
