using System;
using System.Threading.Tasks;
using Vehicle.App.Domain.Shared.Enums;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Vehicle.App.Domain.Order;

public class OrderManager : DomainService
{
    private readonly IRepository<OrderAggregateRoot, Guid> _orderRepository;

    public OrderManager(IRepository<OrderAggregateRoot, Guid> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderAggregateRoot> CreateAsync(
        Guid vehicleId,
        Guid customerId,
        decimal totalAmount,
        DateTime? pickupTime,
        DateTime? returnTime,
        string remarks = null)
    {
        // 检查是否存在未完成的订单
        if (await _orderRepository.AnyAsync(x =>
            x.VehicleId == vehicleId &&
            x.Status != OrderStatus.Completed &&
            x.Status != OrderStatus.Cancelled))
        {
            throw new BusinessException("Order:VehicleInUse");
        }

        return new OrderAggregateRoot(
            vehicleId,
            customerId,
            totalAmount,
            pickupTime,
            returnTime,
            remarks);
    }

    public async Task<OrderDetailEntity> AddOrderDetailAsync(
        OrderAggregateRoot order,
        string itemName,
        decimal unitPrice,
        int quantity,
        string description = null)
    {
        if (order.Status != OrderStatus.Created)
        {
            throw new BusinessException("Order:CannotModify");
        }

        return new OrderDetailEntity(
            order.Id,
            itemName,
            unitPrice,
            quantity,
            description);
    }
}
