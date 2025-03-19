using System;
using Volo.Abp.Domain.Repositories;
namespace Vehicle.App.Order;

/// <summary>
/// 订单表仓储接口
/// </summary>
public interface IOrderRepository : IRepository<OrderAggregateRoot, Guid>
{
}
