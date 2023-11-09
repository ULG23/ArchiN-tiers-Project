using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace JeBalance.Data;

/* This is used if database provider does't define
 * IJeBalanceDbSchemaMigrator implementation.
 */
public class NullJeBalanceDbSchemaMigrator : IJeBalanceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
