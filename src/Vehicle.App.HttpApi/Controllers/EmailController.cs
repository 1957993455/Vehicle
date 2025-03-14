using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.App.Sms;
using Volo.Abp;
using Volo.Abp.Settings;

namespace Vehicle.App.Controllers;

[Route("api/email")]
[RemoteService(Name = "Email")]
public class EmailController : AppController
{

    protected ISMSApplicationService SmsAppSrevice { get; }

    public EmailController(ISMSApplicationService smsAppSrevice)
    {
        SmsAppSrevice = smsAppSrevice;
    }


    /// <summary>
    /// ·¢ËÍÑéÖ¤Âë
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(string email)
    {
        await SmsAppSrevice.SendEmailSmsAsync(email);
        return Ok();
    }

}
