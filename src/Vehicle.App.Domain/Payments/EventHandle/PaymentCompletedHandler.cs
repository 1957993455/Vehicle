// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using Vehicle.App.Order;
using Vehicle.App.Payments.Event;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace Vehicle.App.Payments.EventHandle
{
    // 事件处理器
    public class PaymentCompletedHandler(IRepository<OrderAggregateRoot, Guid> orderRepository) :
        IDistributedEventHandler<PaymentCompletedEvent>,
        ITransientDependency
    {
        private readonly IRepository<OrderAggregateRoot, Guid> _orderRepository = orderRepository;

        public async Task HandleEventAsync(PaymentCompletedEvent eventData)
        {
            var order = await _orderRepository.GetAsync(eventData.OrderId);
            await _orderRepository.UpdateAsync(order);
        }
    }
}
