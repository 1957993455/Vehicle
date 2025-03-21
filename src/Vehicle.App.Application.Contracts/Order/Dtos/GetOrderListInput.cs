using System;
using Vehicle.App.Domain.Shared.Enums;
using Volo.Abp.Application.Dtos;

namespace Vehicle.App.Application.Contracts.Order.Dtos;

public class GetOrderListInput : PagedAndSortedResultRequestDto
{
    public OrderStatus? Status { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? VehicleId { get; set; }
}
