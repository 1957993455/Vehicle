using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Enums;
using Vehicle.App.Permissions;
using Vehicle.App.Vehicle;
using Vehicle.App.Vehicle.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Vehicle.App.Controllers;

[RemoteService]
[Route("api/vehicle")]
[Authorize(AppPermissions.Vehicle.Default)]
public class VehicleController : AppController, IVehicleAppService
{
    private readonly IVehicleAppService _vehicleAppService;

    public VehicleController(IVehicleAppService vehicleAppService)
    {
        _vehicleAppService = vehicleAppService;
    }

    [HttpGet]
    public Task<PagedResultDto<VehicleDto>> GetListAsync([FromQuery] GetListVehicleInput input)
    {
        return _vehicleAppService.GetListAsync(input);
    }

    [HttpGet("{id}")]
    public Task<VehicleDto> GetAsync(Guid id)
    {
        return _vehicleAppService.GetAsync(id);
    }

    [Authorize(AppPermissions.Vehicle.Create)]
    [HttpPost]
    public Task<VehicleDto> CreateAsync(CreateVehicleDto input)
    {
        return _vehicleAppService.CreateAsync(input);
    }

    [Authorize(AppPermissions.Vehicle.Update)]
    [HttpPut("{id}")]
    public Task<VehicleDto> UpdateAsync(Guid id, UpdateVehicleDto input)
    {
        return _vehicleAppService.UpdateAsync(id, input);
    }

    [Authorize(AppPermissions.Vehicle.Delete)]
    [HttpDelete("{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _vehicleAppService.DeleteAsync(id);
    }

    [Authorize(AppPermissions.Vehicle.UpdateMileage)]
    [HttpPut("{id}/mileage")]
    public Task<VehicleDto> UpdateMileageAsync(Guid id, [FromBody] int newMileage)
    {
        return _vehicleAppService.UpdateMileageAsync(id, newMileage);
    }

    [Authorize(AppPermissions.Vehicle.ChangeStatus)]
    [HttpPut("{id}/status")]
    public Task<VehicleDto> ChangeStatusAsync(Guid id, [FromBody] VehicleStatus newStatus)
    {
        return _vehicleAppService.ChangeStatusAsync(id, newStatus);
    }

    [HttpPost("batch-delete")]
    public async Task BatchDeleteAsync([FromBody] Guid[] ids)
    {
        await _vehicleAppService.BatchDeleteAsync(ids);
    }

    [HttpGet("search/{filter?}")]
    public Task<List<VehicleDto>> GetListAsync(string? filter = null) => _vehicleAppService.GetListAsync(filter);
}
