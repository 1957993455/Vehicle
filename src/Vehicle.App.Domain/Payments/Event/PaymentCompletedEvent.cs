
using System;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Vehicle.App.Domain.Payments.Event
{
    /// <summary>
    /// 支付成功事件
    /// </summary>
    public class PaymentCompletedEvent : EtoBase
    {
        public Guid PaymentId { get; }

        public Guid OrderId { get; }

        public PaymentCompletedEvent(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
