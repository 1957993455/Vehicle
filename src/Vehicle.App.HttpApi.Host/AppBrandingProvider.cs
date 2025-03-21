using Microsoft.Extensions.Localization;
using Vehicle.App.Domain.Shared.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Vehicle.App.HttpApi.Host;

[Dependency(ReplaceServices = true)]
public class AppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AppResource> _localizer;

    public AppBrandingProvider(IStringLocalizer<AppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
