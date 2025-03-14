using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Vehicle.App.Controllers;

[RemoteService(true, Name = "Test")]
[Area("test")]
[ControllerName("Test")]
[Route("api/test")]
public class TestController : AppController
{
    [HttpGet]
    public async Task<string> Get()
    {
        await Task.Delay(1000);
        throw new UserFriendlyException("This is a test exception!");
    }
}
