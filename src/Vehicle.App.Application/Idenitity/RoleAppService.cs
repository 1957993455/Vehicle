using System;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Identity;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Vehicle.App.Application.Idenitity
{
    public class RoleAppService : ApplicationService, IRoleAppService
    {

        protected IIdentityRoleRepository IdentityRoleRepository { get; }

        public RoleAppService(IIdentityRoleRepository identityRoleRepository)
        {
            IdentityRoleRepository = identityRoleRepository;
        }



        public async Task UpdateIsDefaultAsync(Guid id, bool isDefault)
        {
            var role = await GetRoleAsync(id);
            if (role == null)
            {
                throw new BusinessException("Role not found.");
            }
            role.IsDefault = isDefault;
            await IdentityRoleRepository.UpdateAsync(role);
        }

        public async Task UpdateIsPublicAsync(Guid id, bool isPublic)
        {
            var role = await GetRoleAsync(id);
            if (role == null)
            {
                throw new BusinessException("Role not found.");
            }
            role.IsPublic = isPublic;
            await IdentityRoleRepository.UpdateAsync(role);
        }

        public async Task UpdateIsStaticAsync(Guid id, bool isStatic)
        {
            var role = await GetRoleAsync(id);

            if (role == null)
            {
                throw new BusinessException("Role not found.");
            }

            role.IsStatic = isStatic;
            await IdentityRoleRepository.UpdateAsync(role);
        }

        private async Task<IdentityRole> GetRoleAsync(Guid id)
        {
            var role = await IdentityRoleRepository.GetAsync(id);
            if (role == null)
            {
                throw new BusinessException("Role not found.");
            }

            return role;
        }
    }
}
