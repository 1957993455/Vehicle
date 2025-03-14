using Vehicle.App.Samples;
using Xunit;

namespace Vehicle.App.EntityFrameworkCore.Domains;

[Collection(AppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AppEntityFrameworkCoreTestModule>
{

}
