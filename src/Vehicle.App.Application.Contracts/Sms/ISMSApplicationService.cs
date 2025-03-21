using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Vehicle.App.Application.Contracts.Sms;

public interface ISMSApplicationService : IApplicationService, ITransientDependency
{
    Task SendEmailSmsAsync(string email);
    Task SendSmsAsync(string mobile, string message);
}
