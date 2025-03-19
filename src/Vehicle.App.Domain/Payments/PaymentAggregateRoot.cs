using System;
using Vehicle.App.Enums;
using Vehicle.App.Payments.Event;
using Volo.Abp.Domain.Entities.Auditing;

namespace Vehicle.App.Payments;

/// <summary>
/// 支付聚合根
/// </summary>
public class PaymentAggregateRoot : FullAuditedAggregateRoot<Guid>
{
    // 关联信息
    public Guid OrderId { get; private set; }  // 订单聚合根ID

    // 支付详情
    public decimal Amount { get; private set; }
    public string PaymentMethod { get; private set; } // Alipay/WeChat/CreditCard
    public string TransactionId { get; private set; } // 第三方支付ID
    public DateTime PaymentTime { get; private set; }

    // 状态
    public PaymentStatus Status { get; private set; }
    public string FailureReason { get; private set; }

    // 构造函数
    protected PaymentAggregateRoot() { }

    public PaymentAggregateRoot(Guid orderId, decimal amount, string paymentMethod)
    {
        OrderId = orderId;
        Amount = amount;
        PaymentMethod = paymentMethod;
    }

    // 领域方法
    public void MarkAsSuccess(string transactionId)
    {
        Status = PaymentStatus.Paid;
        TransactionId = transactionId;
        PaymentTime = DateTime.Now;

        AddDistributedEvent(new PaymentCompletedEvent(Id));
    }

    public void MarkAsFailed(string reason)
    {
        Status = PaymentStatus.Unpaid;
        FailureReason = reason;

    }
}
