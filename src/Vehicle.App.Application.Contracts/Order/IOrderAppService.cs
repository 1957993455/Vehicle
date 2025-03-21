using System;
using Vehicle.App.Application.Contracts.Order.Dtos;
using Volo.Abp.Application.Services;

namespace Vehicle.App.Application.Contracts.Order;

public interface IOrderAppService : ICrudAppService<
    OrderDto,
    Guid,
    GetOrderListInput,
    CreateOrderInput,
    UpdateOrderInput>
{
}
