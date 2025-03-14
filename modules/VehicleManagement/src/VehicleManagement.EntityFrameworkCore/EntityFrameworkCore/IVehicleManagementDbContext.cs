using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace VehicleManagement.EntityFrameworkCore;

[ConnectionStringName(VehicleManagementDbProperties.ConnectionStringName)]
public interface IVehicleManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
