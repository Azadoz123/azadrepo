using Volo.Abp.Settings;

namespace Acme.BookStore1.Settings;

public class BookStore1SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookStore1Settings.MySetting1));
    }
}
