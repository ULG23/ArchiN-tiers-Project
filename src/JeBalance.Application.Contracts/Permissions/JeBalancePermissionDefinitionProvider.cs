using JeBalance.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JeBalance.Permissions;

public class JeBalancePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(JeBalancePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(JeBalancePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<JeBalanceResource>(name);
    }
}
