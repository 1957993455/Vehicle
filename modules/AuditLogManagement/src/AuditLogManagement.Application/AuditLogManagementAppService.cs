using AuditLogManagement.Localization;
using Volo.Abp.Application.Services;

namespace AuditLogManagement;

public abstract class AuditLogManagementAppService : ApplicationService
{
    protected AuditLogManagementAppService()
    {
        LocalizationResource = typeof(AuditLogManagementResource);
        ObjectMapperContext = typeof(AuditLogManagementApplicationModule);
    }
}
