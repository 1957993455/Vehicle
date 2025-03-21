using System.ComponentModel;

namespace Vehicle.App.Domain.Shared.Identity.Enums
{
    public enum SexEnum
    {
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Male = 1,

        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Female = 2,

        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Other = 3
    }
}
