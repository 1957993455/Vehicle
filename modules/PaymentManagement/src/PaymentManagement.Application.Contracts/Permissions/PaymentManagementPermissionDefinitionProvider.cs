using PaymentManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PaymentManagement.Permissions;

public class PaymentManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PaymentManagementPermissions.GroupName, L("Permission:PaymentManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PaymentManagementResource>(name);
    }
}
