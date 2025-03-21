using Vehicle.App.FileManagement.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Vehicle.App.FileManagement.HttpApi;

public abstract class FileManagementController : AbpControllerBase
{
    protected FileManagementController()
    {
        LocalizationResource = typeof(FileManagementResource);
    }
}
