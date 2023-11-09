using System;
using System.Collections.Generic;
using System.Text;
using JeBalance.Localization;
using Volo.Abp.Application.Services;

namespace JeBalance;

/* Inherit your application services from this class.
 */
public abstract class JeBalanceAppService : ApplicationService
{
    protected JeBalanceAppService()
    {
        LocalizationResource = typeof(JeBalanceResource);
    }
}
