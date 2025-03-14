using Volo.Abp.Modularity;

namespace VehicleManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class VehicleManagementApplicationTestBase<TStartupModule> : VehicleManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
