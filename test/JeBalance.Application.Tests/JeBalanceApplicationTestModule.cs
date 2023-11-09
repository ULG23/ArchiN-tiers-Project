using Volo.Abp.Modularity;

namespace JeBalance;

[DependsOn(
    typeof(JeBalanceApplicationModule),
    typeof(JeBalanceDomainTestModule)
    )]
public class JeBalanceApplicationTestModule : AbpModule
{

}
