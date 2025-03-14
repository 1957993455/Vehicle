using AuditLogManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AuditLogManagement;

public abstract class AuditLogManagementController : AbpControllerBase
{
    protected AuditLogManagementController()
    {
        LocalizationResource = typeof(AuditLogManagementResource);
    }
}
