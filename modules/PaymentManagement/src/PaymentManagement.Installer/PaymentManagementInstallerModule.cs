using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace PaymentManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class PaymentManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentManagementInstallerModule>();
        });
    }
}
