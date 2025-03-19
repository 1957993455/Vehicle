using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace Vehicle.App.Sms
{
    /// <summary>
    /// 短信发送服务
    /// </summary>
    public class SMSApplicationService : ApplicationService, ISMSApplicationService
    {
        protected Volo.Abp.Emailing.IEmailSender EmailSender { get; }
        protected IDistributedCache<string> DistributedCache { get; }

        public SMSApplicationService(Volo.Abp.Emailing.IEmailSender emailSender, IDistributedCache<string> distributedCache)
        {
            EmailSender = emailSender;
            DistributedCache = distributedCache;
        }

        public async Task SendEmailSmsAsync(string email)
        {
            //生成验证码
            var code = CreateEmailCode();

            //缓存验证码,默认5分钟
            await DistributedCache.SetAsync(email, code, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
            });
            //发送邮件
            await EmailSender.SendAsync(email, "验证码", $"您的验证码是：{code}");
        }

        /// <summary>
        /// 创建验证码
        /// </summary>
        /// <returns></returns>
        private string CreateEmailCode()
        {
            //生成6位随机数
            return Random.Shared.Next(100000, 999999).ToString();
        }
    }

}
