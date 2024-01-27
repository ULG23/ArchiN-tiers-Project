using JeBalance.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JeBalance.Permissions;

public class JeBalancePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var group = context.AddGroup(JeBalancePermissions.GroupName);

        group.AddPermission(JeBalancePermissions.Admin, L("Permission:Admin"));
        group.AddPermission(JeBalancePermissions.AdminFiscale, L("Permission:AdminFiscale"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<JeBalanceResource>(name);
    }
}
