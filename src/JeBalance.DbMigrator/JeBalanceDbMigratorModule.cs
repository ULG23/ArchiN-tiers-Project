using JeBalance.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace JeBalance.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(JeBalanceEntityFrameworkCoreModule),
    typeof(JeBalanceApplicationContractsModule)
    )]
public class JeBalanceDbMigratorModule : AbpModule
{
}
