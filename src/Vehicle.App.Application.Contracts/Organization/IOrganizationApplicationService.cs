using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.App.Organization.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Vehicle.App.Organization
{
    public interface IOrganizationAppService : ICrudAppService<OrganizationUnitDto, Guid, GetOrganizationUnitInput, CreateOrganizationUnitInput, UpdateOrganizationUnitInput>
    {
        /// <summary>
        /// 获取组织单元树
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<OrganizationUnitDto>> GetOrganizationsTreeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteAsync(IEnumerable<Guid> ids);
    }
}
