using AuditLogManagement.EntityFrameworkCore;
using FileManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehicle.App.Order;
using Vehicle.App.Store;
using Vehicle.App.Vehicle;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Vehicle.App.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AppDbContext :
    AbpDbContext<AppDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    #region Entities from the modules


    // 车辆相关
    public DbSet<VehicleAggregateRoot> Vehicles { get; set; }

    public DbSet<MaintenanceRecordEntity> MaintenanceRecords { get; set; }
    public DbSet<AccidentRecordEntity> AccidentRecords { get; set; }
    public DbSet<VehiclePurchaseRecordEntity> PurchaseRecords { get; set; }

    // 订单相关
    public DbSet<OrderAggregateRoot> Orders { get; set; }

    public DbSet<OrderDetailEntity> OrderDetails { get; set; }

    // 门店相关
    public DbSet<StoreAggregateRoot> Stores { get; set; }

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureAuditLogManagement();
        builder.ConfigureFileManagement();
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
