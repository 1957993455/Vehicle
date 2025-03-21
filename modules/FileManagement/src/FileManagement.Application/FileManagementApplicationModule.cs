using FileManagement.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Vehicle.App.FileManagement.Domain;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Vehicle.App.FileManagement.Application;

[DependsOn(
    typeof(FileManagementDomainModule),
    typeof(FileManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class FileManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<FileManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<FileManagementApplicationModule>(validate: true);
        });
    }
}
