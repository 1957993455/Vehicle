using Volo.Abp.Modularity;

namespace PaymentManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class PaymentManagementDomainTestBase<TStartupModule> : PaymentManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
