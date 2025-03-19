using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Enums;
using Vehicle.App.Vehicle.Dtos;
using Volo.Abp.Application.Services;

namespace Vehicle.App.Vehicle;

public interface IVehicleAppService : ICrudAppService<
    VehicleDto,
    Guid,
    GetListVehicleInput,
    CreateVehicleDto,
    UpdateVehicleDto>
{
    Task<VehicleDto> UpdateMileageAsync(Guid id, int newMileage);

    Task<VehicleDto> ChangeStatusAsync(Guid id, VehicleStatus newStatus);

    Task BatchDeleteAsync(Guid[] ids);


    Task<List<VehicleDto>> GetListAsync(string filter);
}
