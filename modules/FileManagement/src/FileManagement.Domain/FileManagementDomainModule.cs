using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FileManagement;

[DependsOn(
    typeof(BlobStoringDatabaseDomainModule),
    typeof(AbpDddDomainModule),
    typeof(FileManagementDomainSharedModule)
)]
public class FileManagementDomainModule : AbpModule
{

}
