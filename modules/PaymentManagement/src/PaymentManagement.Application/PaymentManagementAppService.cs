using PaymentManagement.Localization;
using Volo.Abp.Application.Services;

namespace PaymentManagement;

public abstract class PaymentManagementAppService : ApplicationService
{
    protected PaymentManagementAppService()
    {
        LocalizationResource = typeof(PaymentManagementResource);
        ObjectMapperContext = typeof(PaymentManagementApplicationModule);
    }
}
