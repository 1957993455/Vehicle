using PaymentManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PaymentManagement;

public abstract class PaymentManagementController : AbpControllerBase
{
    protected PaymentManagementController()
    {
        LocalizationResource = typeof(PaymentManagementResource);
    }
}
