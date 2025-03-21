using Vehicle.App.Application;
using Volo.Abp.Modularity;

namespace Vehicle.App;

[DependsOn(
    typeof(AppApplicationModule),
    typeof(AppDomainTestModule)
)]
public class AppApplicationTestModule : AbpModule
{

}
