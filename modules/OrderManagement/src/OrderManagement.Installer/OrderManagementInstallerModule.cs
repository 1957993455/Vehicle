using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace OrderManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class OrderManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrderManagementInstallerModule>();
        });
    }
}
