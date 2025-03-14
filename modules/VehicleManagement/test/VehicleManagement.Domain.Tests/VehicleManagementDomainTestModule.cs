using Volo.Abp.Modularity;

namespace VehicleManagement;

[DependsOn(
    typeof(VehicleManagementDomainModule),
    typeof(VehicleManagementTestBaseModule)
)]
public class VehicleManagementDomainTestModule : AbpModule
{

}
