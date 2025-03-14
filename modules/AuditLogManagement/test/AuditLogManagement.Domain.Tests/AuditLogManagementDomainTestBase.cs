using Volo.Abp.Modularity;

namespace AuditLogManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class AuditLogManagementDomainTestBase<TStartupModule> : AuditLogManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
