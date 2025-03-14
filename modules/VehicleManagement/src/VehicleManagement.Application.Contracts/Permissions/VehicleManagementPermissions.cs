using Volo.Abp.Reflection;

namespace VehicleManagement.Permissions;

public class VehicleManagementPermissions
{
    public const string GroupName = "VehicleManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(VehicleManagementPermissions));
    }
}
