using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace VehicleManagement;

[DependsOn(
    typeof(VehicleManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class VehicleManagementApplicationContractsModule : AbpModule
{

}
