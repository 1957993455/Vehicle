using Vehicle.App.FileManagement.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace Vehicle.App.FileManagement.Application;

public abstract class FileManagementAppService : ApplicationService
{
    protected FileManagementAppService()
    {
        LocalizationResource = typeof(FileManagementResource);
        ObjectMapperContext = typeof(FileManagementApplicationModule);
    }
}
