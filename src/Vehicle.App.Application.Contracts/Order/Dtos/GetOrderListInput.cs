using System;
using Vehicle.App.Enums;
using Volo.Abp.Application.Dtos;

namespace Vehicle.App.Order.Dtos;

public class GetOrderListInput : PagedAndSortedResultRequestDto
{
    public OrderStatus? Status { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? VehicleId { get; set; }
}
