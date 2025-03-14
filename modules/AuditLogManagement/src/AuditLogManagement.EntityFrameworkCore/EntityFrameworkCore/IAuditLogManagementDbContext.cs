using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AuditLogManagement.EntityFrameworkCore;

[ConnectionStringName(AuditLogManagementDbProperties.ConnectionStringName)]
public interface IAuditLogManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
