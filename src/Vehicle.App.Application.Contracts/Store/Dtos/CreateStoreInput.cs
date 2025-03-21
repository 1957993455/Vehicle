using System.ComponentModel.DataAnnotations;

namespace Vehicle.App.Application.Contracts.Store.Dtos;

public class CreateStoreInput
{
    [Required(ErrorMessage = "名称不能为空")]
    public string Name { get; set; } = null!;


    public string StoreCode { get; set; } = null!;

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }

    public string? ImageUrl { get; set; }
    /// <summary>
    /// 省
    /// </summary>
    public string? Province { get; set; } = null!;

    /// <summary>
    /// 市
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// 区
    /// </summary>
    public string District { get; set; } = null!;

    /// <summary>
    /// 镇
    /// </summary>
    public string? Street { get; set; } = null!;

    /// <summary>
    /// 详细地址
    /// </summary>
    public string? DetailAddress { get; set; } = null!;

    /// <summary>
    /// 行政区划代码
    /// </summary>
    public string? AdCode { get; set; } = null!;
    /// <summary>
    /// 地址级别
    /// </summary>
    public string? Level { get; set; } = null!;


}
