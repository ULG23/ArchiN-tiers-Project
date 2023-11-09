using System.Threading.Tasks;

namespace JeBalance.Data;

public interface IJeBalanceDbSchemaMigrator
{
    Task MigrateAsync();
}
