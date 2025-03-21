using Vehicle.App.FileManagement.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace FileManagement.Application.Contracts;

[DependsOn(
    typeof(FileManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class FileManagementApplicationContractsModule : AbpModule
{

}
