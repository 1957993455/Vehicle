using System;
using Vehicle.App.Order.Dtos;
using Volo.Abp.Application.Services;

namespace Vehicle.App.Order;

public interface IOrderAppService : ICrudAppService<
    OrderDto,
    Guid,
    GetOrderListInput,
    CreateOrderInput,
    UpdateOrderInput>
{
}
