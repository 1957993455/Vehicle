using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AuditLogManagement.EntityFrameworkCore;

[ConnectionStringName(AuditLogManagementDbProperties.ConnectionStringName)]
public class AuditLogManagementDbContext : AbpDbContext<AuditLogManagementDbContext>, IAuditLogManagementDbContext
{
    public DbSet<AuditLogAction> AuditLogActions { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public AuditLogManagementDbContext(DbContextOptions<AuditLogManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureAuditLogManagement();
    }
}
