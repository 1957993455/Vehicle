using AuditLogManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AuditLogManagement.Permissions;

public class AuditLogManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AuditLogManagementPermissions.GroupName, L("Permission:AuditLogManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AuditLogManagementResource>(name);
    }
}
