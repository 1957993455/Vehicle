using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace AuditLogManagement;

[DependsOn(
    typeof(AuditLogManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AuditLogManagementApplicationContractsModule : AbpModule
{

}
