using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.App.Domain.Shared.Openiddict;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict;
using Volo.Abp.OpenIddict.Controllers;
using Volo.Abp.OpenIddict.ExtensionGrantTypes;

namespace Vehicle.App.HttpApi.Host.Controller;

[IgnoreAntiforgeryToken]
[ApiExplorerSettings(IgnoreApi = true)]
public class EmailTokenController : AbpOpenIdDictControllerBase, ITokenExtensionGrant
{
    public const string ExtensionGrantName = OpeniddictConst.Email.GrantType;

    public string Name => ExtensionGrantName;

    public async Task<IActionResult> HandleAsync(ExtensionGrantContext context)
    {
        return await HandleUserAccessTokenAsync(context);
    }

    public async Task<IActionResult> HandleUserAccessTokenAsync(ExtensionGrantContext context)
    {
        //验证验证码
        string? email = context.Request.GetParameter("username").ToString();
        string? code = context.Request.GetParameter("password").ToString();

        //校验参数
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(code))
        {
            return new ForbidResult(
                new[] { OpenIddictServerAspNetCoreDefaults.AuthenticationScheme },
                properties: new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidRequest
                }!));
        }

        var accountAppService = context.HttpContext.RequestServices.GetRequiredService<Application.Contracts.Account.IAccountAppService>();


        //登录校验
        await accountAppService.LoginByEmailAsync(email, code);

        var userManager = context.HttpContext.RequestServices.GetRequiredService<IdentityUserManager>();

        //获取用户
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return new ForbidResult(
                new[] { OpenIddictServerAspNetCoreDefaults.AuthenticationScheme },
                properties: new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidRequest
                }!));
        }

        //判断用户是否被锁定
        if (await userManager.IsLockedOutAsync(user))
        {
            return new ForbidResult(
                new[] { OpenIddictServerAspNetCoreDefaults.AuthenticationScheme },
                properties: new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidRequest
                }!));
        }

        //构建用户信息
        var userClaimsPrincipalFactory = context.HttpContext.RequestServices.GetRequiredService<IUserClaimsPrincipalFactory<Volo.Abp.Identity.IdentityUser>>();
        var claimsPrincipal = await userClaimsPrincipalFactory.CreateAsync(user);

        //设置作用域
        var scopes = GetScopes(context);
        claimsPrincipal.SetScopes(scopes);
        claimsPrincipal.SetResources(await GetResourcesAsync(context, scopes));
        await context.HttpContext.RequestServices.GetRequiredService<AbpOpenIddictClaimsPrincipalManager>().HandleAsync(context.Request, claimsPrincipal);
        return new Microsoft.AspNetCore.Mvc.SignInResult(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme, claimsPrincipal);
    }


    private ImmutableArray<string> GetScopes(ExtensionGrantContext context)
    {
        var scopes = new[] { "VehicleApp_App", "profile", "roles", "email", "phone", "offline_access" }.ToImmutableArray();

        return scopes;
    }

    private async Task<IEnumerable<string>> GetResourcesAsync(ExtensionGrantContext context, ImmutableArray<string> scopes)
    {
        var resources = new List<string>();
        if (!scopes.Any())
        {
            return resources;
        }

        await foreach (string resource in context.HttpContext.RequestServices.GetRequiredService<IOpenIddictScopeManager>().ListResourcesAsync(scopes))
        {
            resources.Add(resource);
        }
        return resources;
    }
}
