using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace JeBalance.Web;

[Dependency(ReplaceServices = true)]
public class JeBalanceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "JeBalance";
}
