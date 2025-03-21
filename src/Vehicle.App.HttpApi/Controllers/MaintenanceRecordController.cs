using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Permissions;
using Vehicle.App.Application.Contracts.Vehicle;
using Vehicle.App.Application.Contracts.Vehicle.Dtos;
using Volo.Abp;

namespace Vehicle.App.HttpApi.Controllers;

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