using Volo.Abp.Reflection;

namespace AuditLogManagement.Permissions;

public class AuditLogManagementPermissions
{
    public const string GroupName = "AuditLogManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AuditLogManagementPermissions));
    }
}
