using Volo.Abp.Modularity;

namespace VehicleManagement;

[DependsOn(
    typeof(VehicleManagementApplicationModule),
    typeof(VehicleManagementDomainTestModule)
    )]
public class VehicleManagementApplicationTestModule : AbpModule
{

}
