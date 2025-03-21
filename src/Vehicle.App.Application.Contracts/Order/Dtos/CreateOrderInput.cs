using System;

namespace Vehicle.App.Application.Contracts.Order.Dtos;

public class CreateOrderInput
{
    public required Guid VehicleId { get; set; }
    public required Guid CustomerId { get; set; }
    public required decimal TotalAmount { get; set; }
    public required DateTime? PickupTime { get; set; }
    public required DateTime? ReturnTime { get; set; }
    public required string Remarks { get; set; }
    public required string ItemName { get; set; }
    public required decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public required string Description { get; set; }
}
