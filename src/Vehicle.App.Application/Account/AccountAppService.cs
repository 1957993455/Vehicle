using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Vehicle.App.Account
{

    public class AccountAppService : ApplicationService, IAccountAppService
    {
        protected IdentityUserManager IdentityUserManager { get; }
        protected IRepository<IdentityUser, Guid> IdentityUserRepository { get; }
        protected IDistributedCache<string> DistributedCache { get; }
        public AccountAppService(
            IdentityUserManager identityUserManager,
             IRepository<IdentityUser, Guid> identityUserRepository,
            IDistributedCache<string> distributedCache
          )
        {
            IdentityUserManager = identityUserManager;
            IdentityUserRepository = identityUserRepository;
            DistributedCache = distributedCache;
        }


        public async Task LoginByPhoneNumberAsync(string phoneNumber, string code)
        {

            //判断验证码是否正确
            var cacheCode = await DistributedCache.GetAsync(phoneNumber);
            if (cacheCode != code)
            {
                throw new UserFriendlyException("验证码错误");
            }

            //判断手机号是否存在，不存在则创建用户
            IdentityUser? user = await IdentityUserRepository.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            if (user == null)
            {
                user = new IdentityUser(GuidGenerator.Create(), string.Empty, string.Empty);
                user.SetPhoneNumber(phoneNumber, true);
                await IdentityUserManager.CreateAsync(user);
            }
        }

        public async Task LoginByEmailAsync(string email, string code)
        {
            //校验参数
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(code))
            {
                throw new UserFriendlyException("参数错误");
            }

            var user = await IdentityUserManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserFriendlyException("用户不存在");
            }
            var cacheCode = await DistributedCache.GetAsync(email);
            if (cacheCode != code)
            {
                throw new UserFriendlyException("验证码错误");
            }
        }
    }

}
