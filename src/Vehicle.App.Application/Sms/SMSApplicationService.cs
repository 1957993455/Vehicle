using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Sms;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Sms;

namespace Vehicle.App.Application.Sms
{
    /// <summary>
    /// 短信发送服务
    /// </summary>
    public class SMSApplicationService : ApplicationService, ISMSApplicationService
    {
        protected Volo.Abp.Emailing.IEmailSender EmailSender { get; }
        protected IDistributedCache<string> DistributedCache { get; }
        protected ISmsSender SmsSender { get; }

        public SMSApplicationService(Volo.Abp.Emailing.IEmailSender emailSender, IDistributedCache<string> distributedCache, ISmsSender smsSender)
        {
            EmailSender = emailSender;
            DistributedCache = distributedCache;
            SmsSender = smsSender;
        }

        public async Task SendEmailSmsAsync(string email)
        {
            //生成验证码
            string code = CreateEmailCode();

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

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendSmsAsync(string mobile, string message)
        {
            var meg = new SmsMessage(mobile, message);
            meg.Properties.Add("SignName", "nunu@1758403425029383.onaliyun.com");
            meg.Properties.Add("TemplateCode", "SMS_302655851");
            await SmsSender.SendAsync(meg);
        }
    }

}
