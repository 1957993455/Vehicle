using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace VehicleManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VehicleManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class VehicleManagementConsoleApiClientModule : AbpModule
{

}
