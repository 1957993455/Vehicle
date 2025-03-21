using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Sms;
using Volo.Abp;

namespace Vehicle.App.HttpApi.Controllers;

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
    /// 发送验证码
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

    /// <summary>
    /// 发送验证码
    /// </summary>
    /// <param name="phone"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("send-phone")]
    public async Task<IActionResult> SendPhone(string phone)
    {
        await SmsAppSrevice.SendSmsAsync(phone, "验证码：{0}");
        return Ok();
    }

}
