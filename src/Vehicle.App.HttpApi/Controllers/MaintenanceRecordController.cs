using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Permissions;
using Vehicle.App.Vehicle;
using Vehicle.App.Vehicle.Dtos;
using Volo.Abp;

namespace Vehicle.App.Controllers;

[RemoteService]
[Route("api/maintenance-record")]
[Authorize(AppPermissions.MaintenanceRecord.Default)]
public class MaintenanceRecordController : AppController
{
    private readonly IMaintenanceRecordAppService _maintenanceRecordAppService;

    public MaintenanceRecordController(IMaintenanceRecordAppService maintenanceRecordAppService)
    {
        _maintenanceRecordAppService = maintenanceRecordAppService;
    }

    [Authorize(AppPermissions.MaintenanceRecord.Create)]
    [HttpPost]
    public Task<MaintenanceRecordDto> CreateAsync(CreateMaintenanceRecordDto input)
    {
        return _maintenanceRecordAppService.CreateAsync(input);
    }

    [Authorize(AppPermissions.MaintenanceRecord.View)]
    [HttpGet("vehicle/{vehicleId}")]
    public Task<List<MaintenanceRecordDto>> GetByVehicleIdAsync(Guid vehicleId)
    {
        return _maintenanceRecordAppService.GetByVehicleIdAsync(vehicleId);
    }
}