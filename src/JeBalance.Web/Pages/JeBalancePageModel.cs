using JeBalance.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JeBalance.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class JeBalancePageModel : AbpPageModel
{
    protected JeBalancePageModel()
    {
        LocalizationResourceType = typeof(JeBalanceResource);
    }
}
