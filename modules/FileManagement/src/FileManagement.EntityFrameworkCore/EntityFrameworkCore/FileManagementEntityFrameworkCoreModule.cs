using Microsoft.Extensions.DependencyInjection;
using Vehicle.App.FileManagement.Domain;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Vehicle.App.FileManagement.EntityFrameworkCore.EntityFrameworkCore;

[DependsOn(
    typeof(FileManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
)]
public class FileManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<FileManagementDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
        });
    }
}
