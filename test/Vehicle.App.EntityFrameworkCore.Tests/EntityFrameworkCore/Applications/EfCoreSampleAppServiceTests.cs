using Vehicle.App.Samples;
using Xunit;

namespace Vehicle.App.EntityFrameworkCore.Applications;

[Collection(AppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AppEntityFrameworkCoreTestModule>
{

}
