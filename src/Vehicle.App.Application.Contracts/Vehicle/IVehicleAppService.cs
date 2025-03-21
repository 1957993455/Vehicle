using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Vehicle.Dtos;
using Vehicle.App.Domain.Shared.Enums;
using Volo.Abp.Application.Services;

namespace Vehicle.App.Application.Contracts.Vehicle;

public interface IVehicleAppService : ICrudAppService<
    VehicleDto,
    Guid,
    GetListVehicleInput,
    CreateVehicleInput,
    UpdateVehicleInput>
{
    Task<VehicleDto> UpdateMileageAsync(Guid id, int newMileage);

    Task<VehicleDto> ChangeStatusAsync(Guid id, VehicleStatus newStatus);

    Task BatchDeleteAsync(Guid[] ids);


    Task<List<VehicleDto>> GetListAsync(string filter);
}
