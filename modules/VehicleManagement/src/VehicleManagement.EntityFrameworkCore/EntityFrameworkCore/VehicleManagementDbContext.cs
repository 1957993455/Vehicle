using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace VehicleManagement.EntityFrameworkCore;

[ConnectionStringName(VehicleManagementDbProperties.ConnectionStringName)]
public class VehicleManagementDbContext : AbpDbContext<VehicleManagementDbContext>, IVehicleManagementDbContext
{
   

    public VehicleManagementDbContext(DbContextOptions<VehicleManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureVehicleManagement();
    }
}
