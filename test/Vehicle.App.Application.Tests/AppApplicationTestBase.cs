using Volo.Abp.Modularity;

namespace Vehicle.App;

public abstract class AppApplicationTestBase<TStartupModule> : AppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
