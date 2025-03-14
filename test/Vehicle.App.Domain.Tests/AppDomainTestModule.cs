using Volo.Abp.Modularity;

namespace Vehicle.App;

[DependsOn(
    typeof(AppDomainModule),
    typeof(AppTestBaseModule)
)]
public class AppDomainTestModule : AbpModule
{

}
