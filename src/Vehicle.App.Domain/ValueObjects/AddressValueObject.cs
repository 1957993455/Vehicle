
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Vehicle.App.Domain.ValueObjects;

/// <summary>
/// 地址值对象
/// </summary>
public class AddressValueObject : ValueObject
{

    private AddressValueObject()
    {
    }

    public AddressValueObject(
        string province, string city, string district, string street, string detail, string level, string adCode,
        string longitude, string latitude)
    {
        Province = province;
        City = city;
        District = district;
        Street = street;
        Detail = detail;
        Level = level;
        AdCode = adCode;
        Longitude = longitude;
        Latitude = latitude;
    }


    /// <summary>
    /// 省
    /// </summary>
    public string Province { get; private init; }
    /// <summary>
    /// 市
    /// </summary>
    public string City { get; private init; }
    /// <summary>
    /// 区
    /// </summary>
    public string District { get; private init; }
    /// <summary>
    /// 街道
    /// </summary>
    public string Street { get; private init; }
    /// <summary>
    /// 详细地址
    /// </summary>
    public string Detail { get; private init; }

    /// <summary>
    /// 地址级别
    /// </summary>
    public string Level { get; private init; }

    /// <summary>
    /// 行政区划代码
    /// </summary>
    public string AdCode { get; private set; }
    /// <summary>
    /// 经度
    /// </summary>
    public string Longitude { get; private set; }

    /// <summary>
    /// 纬度
    /// </summary>
    public string Latitude { get; private set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Province;
        yield return City;
        yield return District;
        yield return Street;
        yield return Detail;
    }
}
