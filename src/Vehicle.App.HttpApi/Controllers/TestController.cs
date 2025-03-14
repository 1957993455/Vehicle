using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;

namespace Vehicle.App.Controllers;

[RemoteService(true, Name = "Test")]
[Area("test")]
[ControllerName("Test")]
[Route("api/test")]
public class TestController : AppController
{
    protected IDistributedCache<string> Cache { get; }
    public TestController(IDistributedCache<string> cache)
    {
        Cache = cache;
    }
    [HttpGet]
    public async Task<string> Get()
    {
        await Cache.SetAsync("abpp_test", "abp");
        await Task.Delay(1000);
       var res= await Cache.GetAsync("abpp_test");
        return "abp";
    }
}
