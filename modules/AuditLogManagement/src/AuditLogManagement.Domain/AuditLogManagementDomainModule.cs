using Volo.Abp.AuditLogging;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AuditLogManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AuditLogManagementDomainSharedModule)
)]

public class AuditLogManagementDomainModule : AbpModule
{

}
