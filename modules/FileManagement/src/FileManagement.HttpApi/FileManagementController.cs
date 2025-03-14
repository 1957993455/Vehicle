using FileManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FileManagement;

public abstract class FileManagementController : AbpControllerBase
{
    protected FileManagementController()
    {
        LocalizationResource = typeof(FileManagementResource);
    }
}
