using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace OrderManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OrderManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class OrderManagementConsoleApiClientModule : AbpModule
{

}
