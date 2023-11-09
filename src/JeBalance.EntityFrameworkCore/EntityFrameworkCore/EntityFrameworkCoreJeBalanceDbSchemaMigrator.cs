using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JeBalance.Data;
using Volo.Abp.DependencyInjection;

namespace JeBalance.EntityFrameworkCore;

public class EntityFrameworkCoreJeBalanceDbSchemaMigrator
    : IJeBalanceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreJeBalanceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the JeBalanceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<JeBalanceDbContext>()
            .Database
            .MigrateAsync();
    }
}
