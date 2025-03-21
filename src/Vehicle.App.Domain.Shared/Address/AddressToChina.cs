using System.Collections.Generic;

namespace Vehicle.App.Domain.Shared.Address;

public static class AddressToChina
{
    /// <summary>
    /// 地区字典
    /// </summary>
    public static readonly Dictionary<string, string> China = new Dictionary<string, string>()
    {
      {"北京","BJ"},
      {"上海","SH"},
      {"深圳","SZ"},
      {"贵州","GZ"},
      {"四川","SC"},
      {"云南","YN"},
      {"湖北","HB"},
      {"湖南","HN"},
      {"河南","HE"},
      {"河北","HE"},
      {"山西","SX"},
      {"陕西","SN"},
      {"甘肃","GS"},
      {"青海","QH"},
      {"西藏","XZ"},
      {"宁夏","NX"},
      {"内蒙古","NM"},
      {"新疆","XJ"},
      {"台湾","TW"},
      {"香港","HK"},
      {"澳门","MO"},
      {"吉林","JL"},
      {"辽宁","LN"},
      {"黑龙江","HLJ"},
      {"江苏","JS"},
      {"浙江","ZJ"},
      {"安徽","AH"},
      {"福建","FJ"},
      {"江西","JX"},
      {"山东","SD"},

    };


    public static string GetChinaEg(this string obj)
    {
        if (China.TryGetValue(obj, out var value))
        {
            return value;
        }
        return obj;
    }
}