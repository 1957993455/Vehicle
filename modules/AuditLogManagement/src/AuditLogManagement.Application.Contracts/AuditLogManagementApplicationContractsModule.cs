using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace AuditLogManagement;

[DependsOn(
    typeof(AuditLogManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AuditLogManagementApplicationContractsModule : AbpModule
{

}
