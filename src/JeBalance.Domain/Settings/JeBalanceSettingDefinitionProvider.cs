using Volo.Abp.Settings;

namespace JeBalance.Settings;

public class JeBalanceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(JeBalanceSettings.MySetting1));
    }
}
