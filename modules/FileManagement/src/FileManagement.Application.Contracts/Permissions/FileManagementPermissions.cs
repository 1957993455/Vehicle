using Volo.Abp.Reflection;

namespace FileManagement.Application.Contracts.Permissions;

public class FileManagementPermissions
{
    public const string GroupName = "FileManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(FileManagementPermissions));
    }
}
