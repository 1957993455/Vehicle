using Microsoft.EntityFrameworkCore;
using Vehicle.App.Identity;
using Vehicle.App.Identity.Enums;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Vehicle.App.EntityFrameworkCore;

public static class AppEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        AppGlobalFeatureConfigurator.Configure();
        AppModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
                //添加用户拓展属性
                ObjectExtensionManager.Instance
                    .MapEfCoreProperty<IdentityUser, string?>(
                        IdentityConst.User.realName,
                        (entityBuilder, propertyBuilder) =>
                        {
                            propertyBuilder.HasMaxLength(128);
                        }
                    )
                    .MapEfCoreProperty<IdentityUser, string?>(
                    IdentityConst.User.avatar, (entityBuilder, propertyBuilder) =>
                    {
                    })
                    .MapEfCoreProperty<IdentityUser, SexEnum?>(
                    IdentityConst.User.sex, (entityBuilder, propertyBuilder) => { })
                    .MapEfCoreProperty<IdentityUser, string?>(IdentityConst.User.idCardNo, (e, p) =>
                    {
                    })
                    .MapEfCoreProperty<IdentityUser, bool?>(IdentityConst.User.isVerified, (e, p) => { })
                    .MapEfCoreProperty<IdentityUser, int?>(IdentityConst.User.age, (e, p) => { })
                    .MapEfCoreProperty<IdentityUser, string?>(IdentityConst.User.address, (e, p) => { })
                    .MapEfCoreProperty<IdentityUser, string?>(IdentityConst.User.country, (e, p) => { })
                    .MapEfCoreProperty<IdentityUser, string?>(IdentityConst.User.area, (e, p) => { })
                    .MapEfCoreProperty<IdentityUser, string?>(IdentityConst.User.description, (e, p) => { })
                    .MapEfCoreProperty<IdentityUser, string?>(IdentityConst.WeChat.wxOpenId, (e, p) => { })
                    .MapEfCoreProperty<IdentityUser, string?>(IdentityConst.WeChat.wxUnionId, (e, p) => { });

                //添加角色拓展属性
                ObjectExtensionManager.Instance
                    .MapEfCoreProperty<IdentityRole, string?>(
                        IdentityConst.Role.displayName,
                        (entityBuilder, propertyBuilder) =>
                        {
                            propertyBuilder.HasMaxLength(256);
                        }
                    );
        });
    }
}
