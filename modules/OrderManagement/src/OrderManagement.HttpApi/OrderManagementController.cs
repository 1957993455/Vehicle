using OrderManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OrderManagement;

public abstract class OrderManagementController : AbpControllerBase
{
    protected OrderManagementController()
    {
        LocalizationResource = typeof(OrderManagementResource);
    }
}
