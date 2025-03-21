using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Order;
using Vehicle.App.Application.Contracts.Order.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Vehicle.App.HttpApi.Controllers;

[RemoteService]
[Route("api/orders")]
[Area("Orders")]
[Authorize]
public class OrderController : AppController
{
    private readonly IOrderAppService _orderAppService;

    public OrderController(IOrderAppService orderAppService)
    {
        _orderAppService = orderAppService;
    }

    [HttpGet]
    public Task<PagedResultDto<OrderDto>> GetListAsync([FromQuery] GetOrderListInput input)
    {
        return _orderAppService.GetListAsync(input);
    }

    [HttpGet("{id}")]
    public Task<OrderDto> GetAsync(Guid id)
    {
        return _orderAppService.GetAsync(id);
    }

    [HttpPost]
    public Task<OrderDto> CreateAsync([FromBody] CreateOrderInput input)
    {
        return _orderAppService.CreateAsync(input);
    }

    [HttpPut("{id}")]
    public Task<OrderDto> UpdateAsync(Guid id, [FromBody] UpdateOrderInput input)
    {
        return _orderAppService.UpdateAsync(id, input);
    }

    [HttpDelete("{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _orderAppService.DeleteAsync(id);
    }
}
