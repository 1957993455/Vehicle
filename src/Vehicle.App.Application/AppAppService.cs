using Vehicle.App.Localization;
using Volo.Abp.Application.Services;

namespace Vehicle.App;

/* Inherit your application services from this class.
 */
public abstract class AppAppService : ApplicationService
{
    protected AppAppService()
    {
        LocalizationResource = typeof(AppResource);
    }
}
