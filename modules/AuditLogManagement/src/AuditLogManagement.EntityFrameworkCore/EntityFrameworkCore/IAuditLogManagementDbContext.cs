using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AuditLogManagement.EntityFrameworkCore;

[ConnectionStringName(AuditLogManagementDbProperties.ConnectionStringName)]
public interface IAuditLogManagementDbContext : IEfCoreDbContext
{
    public DbSet<AuditLogAction> AuditLogActions { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
}
