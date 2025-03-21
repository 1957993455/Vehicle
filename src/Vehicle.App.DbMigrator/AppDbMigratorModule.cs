using Vehicle.App.Application.Contracts;
using Vehicle.App.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Vehicle.App.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AppEntityFrameworkCoreModule),
    typeof(AppApplicationContractsModule)
)]
public class AppDbMigratorModule : AbpModule
{
}
