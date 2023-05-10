using Acme.BookStore1.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore1.Permissions;

public class BookStore1PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookStore1Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStore1Permissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStore1Resource>(name);
    }
}
