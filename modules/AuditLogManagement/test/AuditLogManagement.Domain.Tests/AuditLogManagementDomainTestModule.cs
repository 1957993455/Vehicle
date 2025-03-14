using Volo.Abp.Modularity;

namespace AuditLogManagement;

[DependsOn(
    typeof(AuditLogManagementDomainModule),
    typeof(AuditLogManagementTestBaseModule)
)]
public class AuditLogManagementDomainTestModule : AbpModule
{

}
