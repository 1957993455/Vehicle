// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Vehicle.App.Payments.Event
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
