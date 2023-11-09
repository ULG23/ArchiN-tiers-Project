using JeBalance.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JeBalance;

[DependsOn(
    typeof(JeBalanceEntityFrameworkCoreTestModule)
    )]
public class JeBalanceDomainTestModule : AbpModule
{

}
