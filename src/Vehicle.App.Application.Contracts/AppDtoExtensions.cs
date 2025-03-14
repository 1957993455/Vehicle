using System;
using Vehicle.App.Identity;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Vehicle.App;

public static class AppDtoExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance
           .AddOrUpdateProperty<IdentityUserDto, string>(
                      IdentityConst.User.avatar.ToCamelCase()
            )
           .AddOrUpdateProperty<IdentityUserDto, string>(
                      IdentityConst.User.realName.ToCamelCase()
            )
           .AddOrUpdateProperty<IdentityUserDto, string>(
                      IdentityConst.User.age.ToCamelCase()
            )
           .AddOrUpdateProperty<IdentityUserDto, string>(
                      IdentityConst.User.area.ToCamelCase()
            )
           .AddOrUpdateProperty<IdentityUserDto, string>(
                      IdentityConst.User.description.ToCamelCase()
            )
           .AddOrUpdateProperty<IdentityUserDto, bool>(
                      IdentityConst.User.idCardNo.ToCamelCase()
            );
            ObjectExtensionManager.Instance
                    .AddOrUpdateProperty<GetIdentityUsersInput, Guid?>(
                        "OrganizationUnitId"
                    )
                    .AddOrUpdateProperty<GetIdentityUsersInput, string?>(
                        "OrganizationUnitName"
                    );
        });
    }
}
