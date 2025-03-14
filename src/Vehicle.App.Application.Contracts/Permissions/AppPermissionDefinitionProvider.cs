using Vehicle.App.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Vehicle.App.Permissions;

public class AppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AppPermissions.GroupName);

        // 组织分组
        var orgGroup = context.AddGroup(
            AppPermissions.Organization.GroupName,
            L("Permission:OrganizationManagement"));

        var orgPermission = orgGroup.AddPermission(
            AppPermissions.Organization.Default,
            L("Permission:Organization"));

        orgPermission.AddChild(
            AppPermissions.Organization.Create,
            L("Permission:Organization.Create"));
        orgPermission.AddChild(
            AppPermissions.Organization.Update,
            L("Permission:Organization.Update"));
        orgPermission.AddChild(
            AppPermissions.Organization.Delete,
            L("Permission:Organization.Delete"));
        orgPermission.AddChild(
            AppPermissions.Organization.ManageMembers,
            L("Permission:Organization.ManageMembers"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AppResource>(name);
    }
}
