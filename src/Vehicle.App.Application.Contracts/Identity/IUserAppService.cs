using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Vehicle.App.Application.Contracts.Identity;

/// <summary>
/// 
/// </summary>
public interface IUserAppService : IApplicationService, ITransientDependency
{
    Task BatchDeleteUsers(IEnumerable<Guid> userIds);

    Task UpdatePhoneNumber(Guid userId, string phoneNumber);
    Task UpdateAvatarAsync(Guid id, string avatar);
    Task UpdateStatus(Guid userId, bool isEnabled);
}
