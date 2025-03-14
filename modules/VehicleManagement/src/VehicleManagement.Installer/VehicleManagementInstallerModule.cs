using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace VehicleManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class VehicleManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<VehicleManagementInstallerModule>();
        });
    }
}
