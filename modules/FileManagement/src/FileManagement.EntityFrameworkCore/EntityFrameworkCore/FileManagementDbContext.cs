using Microsoft.EntityFrameworkCore;
using Vehicle.App.FileManagement.Domain;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Vehicle.App.FileManagement.EntityFrameworkCore.EntityFrameworkCore;

[ConnectionStringName(FileManagementDbProperties.ConnectionStringName)]
public class FileManagementDbContext : AbpDbContext<FileManagementDbContext>, IFileManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public FileManagementDbContext(DbContextOptions<FileManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureBlobStoring();
        builder.ConfigureFileManagement();
    }
}
