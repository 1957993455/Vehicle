using VehicleManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VehicleManagement;

public abstract class VehicleManagementController : AbpControllerBase
{
    protected VehicleManagementController()
    {
        LocalizationResource = typeof(VehicleManagementResource);
    }
}
