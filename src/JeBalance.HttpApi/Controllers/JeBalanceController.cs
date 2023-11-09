using JeBalance.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JeBalance.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class JeBalanceController : AbpControllerBase
{
    protected JeBalanceController()
    {
        LocalizationResource = typeof(JeBalanceResource);
    }
}
