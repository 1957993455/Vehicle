using Vehicle.App.FileManagement.Domain;
using Volo.Abp.Modularity;

namespace FileManagement;

[DependsOn(
    typeof(FileManagementDomainModule),
    typeof(FileManagementTestBaseModule)
)]
public class FileManagementDomainTestModule : AbpModule
{

}
