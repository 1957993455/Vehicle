using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Vehicle.App.Identity
{
    public interface IRoleAppService : IApplicationService, ITransientDependency
    {
    }
}
