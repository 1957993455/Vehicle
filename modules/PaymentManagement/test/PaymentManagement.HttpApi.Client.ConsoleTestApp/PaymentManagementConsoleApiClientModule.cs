using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace PaymentManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PaymentManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class PaymentManagementConsoleApiClientModule : AbpModule
{

}
