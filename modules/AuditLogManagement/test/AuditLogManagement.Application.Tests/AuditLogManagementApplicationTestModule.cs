using Volo.Abp.Modularity;

namespace AuditLogManagement;

[DependsOn(
    typeof(AuditLogManagementApplicationModule),
    typeof(AuditLogManagementDomainTestModule)
    )]
public class AuditLogManagementApplicationTestModule : AbpModule
{

}
