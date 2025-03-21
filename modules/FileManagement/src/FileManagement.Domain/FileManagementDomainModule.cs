using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using Vehicle.App.FileManagement.Domain.Shared;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Vehicle.App.FileManagement.Domain;

[DependsOn(
    typeof(BlobStoringDatabaseDomainModule),
    typeof(AbpDddDomainModule),
    typeof(FileManagementDomainSharedModule)
)]
[DependsOn(typeof(AbpBlobStoringFileSystemModule))]
public class FileManagementDomainModule : AbpModule
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {


       

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FileManagementDomainModule>();
        });
    }

}
