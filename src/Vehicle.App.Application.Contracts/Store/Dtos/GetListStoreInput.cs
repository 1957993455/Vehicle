using Vehicle.App.Enums;
using Volo.Abp.Application.Dtos;

namespace Vehicle.App.Store.Dtos;

public class GetListStoreInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }
    public StoreStatus? Status { get; set; }
}
