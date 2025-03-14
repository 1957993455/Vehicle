using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace VehicleManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(VehicleManagementDomainSharedModule)
)]
public class VehicleManagementDomainModule : AbpModule
{

}
