using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Vehicle.Dtos;
using Volo.Abp.Application.Services;

namespace Vehicle.App.Application.Contracts.Vehicle;

public interface IMaintenanceRecordAppService : IApplicationService
{
    Task<MaintenanceRecordDto> CreateAsync(CreateMaintenanceRecordDto input);
    Task<List<MaintenanceRecordDto>> GetByVehicleIdAsync(Guid vehicleId);
}