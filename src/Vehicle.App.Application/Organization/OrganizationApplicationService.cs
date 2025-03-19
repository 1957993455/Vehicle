using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.App.Organization.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Vehicle.App.Organization;

public class OrganizationAppService(
    IOrganizationUnitRepository organizationUnitRepository,
    IRepository<OrganizationUnit, Guid> repository,
    OrganizationUnitManager organizationUnitManager) :
    CrudAppService<OrganizationUnit, OrganizationUnitDto, Guid, GetOrganizationUnitInput, CreateOrganizationUnitInput, UpdateOrganizationUnitInput>(repository)
    , IOrganizationAppService
{
    public async Task<List<OrganizationUnitDto>> GetOrganizationsTreeAsync(CancellationToken cancellationToken = default)
    {
        var orgList = await organizationUnitRepository.GetListAsync(cancellationToken: cancellationToken);

        var orgTree = ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(orgList)
            .Select(x => new OrganizationUnitDto
            {
                Id = x.Id,
                Code = x.Code,
                DisplayName = x.DisplayName,
                ParentId = x.ParentId,
                CreationTime = x.CreationTime,
                LastModificationTime = x.LastModificationTime,
                LastModifierId = x.LastModifierId,
                Children = []
            })
            .ToList();

        var dict = orgTree.ToDictionary(x => x.Id);

        List<OrganizationUnitDto> rootNodes = [];

        foreach (var node in orgTree)
        {
            if (node.ParentId.HasValue)
            {
                if (dict.TryGetValue(node.ParentId.Value, out var parent))
                {
                    parent.Children.Add(node);
                }
                else
                {
                    rootNodes.Add(node);
                }
            }
            else
            {
                rootNodes.Add(node);
            }
        }

        return rootNodes;
    }

    public Task DeleteAsync(IEnumerable<Guid> ids) => throw new NotImplementedException();


    public override async Task DeleteAsync(Guid id)
    {

        var organizationUnit = await organizationUnitManager.FindChildrenAsync(id);
        if (organizationUnit.Any())
        {
            throw new UserFriendlyException("不能删除有子节点的组织");
        }

        await organizationUnitManager.DeleteAsync(id);
    }

}
