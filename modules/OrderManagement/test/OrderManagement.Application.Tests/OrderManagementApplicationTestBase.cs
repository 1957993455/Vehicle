using Volo.Abp.Modularity;

namespace OrderManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class OrderManagementApplicationTestBase<TStartupModule> : OrderManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
