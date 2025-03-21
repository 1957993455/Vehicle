namespace Vehicle.App.Domain.Shared.Openiddict;

public static class OpeniddictConst
{
    //授权类型
    public static class Email
    {
        public const string GrantType = "email";
        public const string ParamName = "email";
        public const string TokenName = "email_verify_code";
        public const string Purpose = "email_verify";
        public const string SecurityCodeFailed = "SecurityCodeFailed";
    }

    public static class WeChat
    {
        public const string GrantType = "wechat";
        public const string ParamName = "code";
        public const string OpenIdParamName = "openid";
        public const string UnionIdParamName = "unionid";
        public const string Purpose = "wechat_login";
    }
}