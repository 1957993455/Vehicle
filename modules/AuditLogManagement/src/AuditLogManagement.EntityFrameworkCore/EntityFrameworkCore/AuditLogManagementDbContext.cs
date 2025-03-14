using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AuditLogManagement.EntityFrameworkCore;

[ConnectionStringName(AuditLogManagementDbProperties.ConnectionStringName)]
public class AuditLogManagementDbContext : AbpDbContext<AuditLogManagementDbContext>, IAuditLogManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public AuditLogManagementDbContext(DbContextOptions<AuditLogManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureAuditLogging();
        builder.ConfigureAuditLogManagement();
    }
}
