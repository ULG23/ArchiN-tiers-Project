using System.Threading.Tasks;
using JeBalance.Localization;
using JeBalance.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace JeBalance.Web.Menus;

public class JeBalanceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<JeBalanceResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                JeBalanceMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.Items.Insert(
          1,
          new ApplicationMenuItem(
              JeBalanceMenus.DenonciationSuivi,
              l["DenonciationSuivi"],
              "/DenonciationSuivi",
              icon: "fas fa-search",
              order: 0
          )
      );


        
            context.Menu.Items.Insert(
          2,
          new ApplicationMenuItem(
              JeBalanceMenus.PersonneVIP,
              l["PersonneVIP"],
              "/PersonneVIP",
              icon: "fas fa-users",
              order: 0
          )
      );

        context.Menu.Items.Insert(
          3,
          new ApplicationMenuItem(
              JeBalanceMenus.TokenGenerator,
              l["TokenGenerator"],
              "/TokenGenerator",
              icon: "fas fa-key",
              order: 0
          )
      );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
