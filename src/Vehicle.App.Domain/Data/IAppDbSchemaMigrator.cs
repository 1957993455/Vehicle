using System.Threading.Tasks;

namespace Vehicle.App.Data;

public interface IAppDbSchemaMigrator
{
    Task MigrateAsync();
}
