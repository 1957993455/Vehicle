using System;
using Vehicle.App.Application.Contracts.Vehicle.Dtos;
using Volo.Abp.Application.Services;

namespace Vehicle.App.Application.Contracts.Vehicle;

/// <summary>
/// 车辆购买记录应用服务接口
/// </summary>
public interface IVehiclePurchaseRecordAppService : ICrudAppService<
    VehiclePurchaseRecordDto,
    Guid,
    GetVehiclePurchaseRecordListInput,
    CreateVehiclePurchaseRecordDto,
    UpdateVehiclePurchaseRecordDto>
{
}
