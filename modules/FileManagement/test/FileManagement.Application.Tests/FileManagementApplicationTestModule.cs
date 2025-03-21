using Vehicle.App.FileManagement.Application;
using Volo.Abp.Modularity;

namespace FileManagement;

[DependsOn(
    typeof(FileManagementApplicationModule),
    typeof(FileManagementDomainTestModule)
    )]
public class FileManagementApplicationTestModule : AbpModule
{

}
