using System;
using Vehicle.App.Enums;
using Volo.Abp.Application.Dtos;

namespace Vehicle.App.Order.Dtos;

public class OrderDto : AuditedEntityDto<Guid>
{
    public Guid VehicleId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public DateTime? PickupTime { get; set; }
    public DateTime? ReturnTime { get; set; }
    public string Remarks { get; set; }
}
