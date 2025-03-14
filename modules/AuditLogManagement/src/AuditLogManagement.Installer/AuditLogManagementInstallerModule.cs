using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AuditLogManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AuditLogManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AuditLogManagementInstallerModule>();
        });
    }
}
