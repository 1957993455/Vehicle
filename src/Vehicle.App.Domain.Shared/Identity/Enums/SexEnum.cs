using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.App.Identity.Enums
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
