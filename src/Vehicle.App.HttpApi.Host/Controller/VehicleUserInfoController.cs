using Microsoft.OpenApi.Extensions;
using OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Identity;
using Vehicle.App.Identity.Enums;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Vehicle.App.Controller;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(Volo.Abp.OpenIddict.Controllers.UserInfoController))]
public class UserInfoController : Volo.Abp.OpenIddict.Controllers.UserInfoController
{

    protected override async Task<Dictionary<string, object>> GetUserInfoClaims()
    {
        var user = await UserManager.GetUserAsync(User);
        if (user == null)
        {
            return new Dictionary<string, object>();
        }

        var claims = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            // Note: the "sub" claim is a mandatory claim and must be included in the JSON response.
            [OpenIddictConstants.Claims.Subject] = await UserManager.GetUserIdAsync(user)
        };

        if (User.HasScope(OpenIddictConstants.Scopes.Profile))
        {
            claims[AbpClaimTypes.TenantId] = user.TenantId!;
            claims[OpenIddictConstants.Claims.PreferredUsername] = user.UserName;
            claims[OpenIddictConstants.Claims.FamilyName] = user.Surname;
            claims[OpenIddictConstants.Claims.GivenName] = user.Name;
            claims["avatar"] = user.GetProperty<string>(IdentityConst.User.avatar) ?? string.Empty;
            claims["userId"] = user.Id.ToString();
            SexEnum? sex = user.GetProperty<SexEnum?>(IdentityConst.User.sex);
            claims["gender"] = sex is null ? SexEnum.Other.GetDisplayName() : sex.GetDisplayName();
            claims["nickname"] = user.GetProperty<string>(IdentityConst.User.realName) ?? string.Empty;
            claims["registrationDate"] = user.CreationTime.ToString("yyyy-MM-dd");
            claims["country"] = user.GetProperty<string>(IdentityConst.User.country) ?? string.Empty;
            claims["area"] = user.GetProperty<string>(IdentityConst.User.area) ?? string.Empty;
            claims["address"] = user.GetProperty<string>(IdentityConst.User.address) ?? string.Empty;
            claims["description"] = user.GetProperty<string>(IdentityConst.User.description) ?? string.Empty;
            claims["isVerified"] = user.GetProperty<bool>(IdentityConst.User.isVerified) ? "已认证" : "未认证";
        }

        if (User.HasScope(OpenIddictConstants.Scopes.Email))
        {
            claims[OpenIddictConstants.Claims.Email] = await UserManager.GetEmailAsync(user) ?? string.Empty;
            claims[OpenIddictConstants.Claims.EmailVerified] = await UserManager.IsEmailConfirmedAsync(user);
        }

        if (User.HasScope(OpenIddictConstants.Scopes.Phone))
        {
            claims[OpenIddictConstants.Claims.PhoneNumber] = await UserManager.GetPhoneNumberAsync(user) ?? string.Empty;
            claims[OpenIddictConstants.Claims.PhoneNumberVerified] = await UserManager.IsPhoneNumberConfirmedAsync(user);
        }

        if (User.HasScope(OpenIddictConstants.Scopes.Roles))
        {
            claims[OpenIddictConstants.Claims.Role] = await UserManager.GetRolesAsync(user);
        }

        return claims;
    }
}
