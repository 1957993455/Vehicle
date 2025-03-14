using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AuditLogManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AuditLogManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AuditLogManagementConsoleApiClientModule : AbpModule
{

}
