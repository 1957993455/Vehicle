using Xunit;

namespace Vehicle.App.EntityFrameworkCore;

[CollectionDefinition(AppTestConsts.CollectionDefinitionName)]
public class AppEntityFrameworkCoreCollection : ICollectionFixture<AppEntityFrameworkCoreFixture>
{

}
