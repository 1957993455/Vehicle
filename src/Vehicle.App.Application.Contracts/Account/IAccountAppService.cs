using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Vehicle.App.Account;

public interface IAccountAppService : IApplicationService, ITransientDependency
{
    /// <summary>
    /// 手机号登录
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    Task LoginByPhoneNumberAsync(string phoneNumber, string code);

    /// <summary>
    /// 邮箱登录
    /// </summary>
    /// <param name="email"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    Task LoginByEmailAsync(string email, string code);
}
