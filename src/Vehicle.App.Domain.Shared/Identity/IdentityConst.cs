namespace Vehicle.App.Domain.Shared.Identity
{
    public static class IdentityConst
    {
        public class WeChat
        {
            public static string wxOpenId = nameof(wxOpenId);
            public static string wxUnionId = nameof(wxUnionId);
        }
        public class User
        {
            public const string avatar = nameof(avatar);
            public const string realName = nameof(realName);
            public const string address = nameof(address);
            public const string age = nameof(age);
            public const string sex = nameof(sex);
            public const string idCardNo = nameof(idCardNo);
            public const string isVerified = nameof(isVerified);
            //国家
            public const string country = nameof(country);
            //区域
            public const string area = nameof(area);
            //描述
            public const string description = nameof(description);
        }

        public class Role
        {
            public const string displayName = nameof(displayName);
        }
    }
}
