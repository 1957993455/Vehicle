using System.Threading.Tasks;

namespace Vehicle.App.Domain.Data;

public interface IAppDbSchemaMigrator
{
    Task MigrateAsync();
}
