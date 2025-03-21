using Vehicle.App.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Vehicle.App.HttpApi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AppController : AbpControllerBase
{
    protected AppController()
    {
        LocalizationResource = typeof(AppResource);
    }
}
