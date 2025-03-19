using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.App.Identity;
using Volo.Abp;
using Volo.Abp.Identity;

namespace Vehicle.App.Controllers;

/// <summary>
/// RoleController
/// </summary>
[RemoteService]
[Microsoft.AspNetCore.Mvc.Route("api/identity/roles")]
[Area(IdentityRemoteServiceConsts.ModuleName)]
[ControllerName("Role")]
public class RoleController : AppController, IRoleAppService
{
    protected IIdentityUserAppService UserAppService { get; }
    protected IRoleAppService RoleAppService { get; }

    public RoleController(IIdentityUserAppService userAppService, IRoleAppService roleAppService)
    {
        UserAppService = userAppService;
        RoleAppService = roleAppService;
    }

    /// <summary>
    /// get role by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId}/role-names")]
    public async Task<IEnumerable<string>> GetRoleNamesByUserIdAsync(Guid userId)
    {
        Volo.Abp.Application.Dtos.ListResultDto<IdentityRoleDto> resultDto = await UserAppService.GetRolesAsync(userId);

        return resultDto.Items.Select(x => x.Name);
    }

    /// <summary>
    /// update role is default
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isDefault"></param>
    /// <returns></returns>
    [HttpPut("{id}/is-default/{isDefault}")]
    public async Task UpdateIsDefaultAsync(Guid id, bool isDefault)
    {
        await RoleAppService.UpdateIsDefaultAsync(id, isDefault);
    }

    /// <summary>
    /// update role is public
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isPublic"></param>
    /// <returns></returns>
    [HttpPut("{id}/is-public/{isPublic}")]
    public async Task UpdateIsPublicAsync(Guid id, bool isPublic)
    {
        await RoleAppService.UpdateIsPublicAsync(id, isPublic);
    }

    /// <summary>
    /// update role is static
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isStatic"></param>
    /// <returns></returns>
    [HttpPut("{id}/is-static/{isStatic}")]
    public async Task UpdateIsStaticAsync(Guid id, bool isStatic)
    {
        await RoleAppService.UpdateIsStaticAsync(id, isStatic);
    }
}
