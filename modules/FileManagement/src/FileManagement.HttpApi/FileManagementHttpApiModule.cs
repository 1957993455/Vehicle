using FileManagement.Application.Contracts;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Vehicle.App.FileManagement.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Vehicle.App.FileManagement.HttpApi;

[DependsOn(
    typeof(FileManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class FileManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(FileManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FileManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
