using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Store.Dtos;
using Vehicle.App.Domain.Shared.Enums;
using Volo.Abp.Application.Services;

namespace Vehicle.App.Application.Contracts.Store;

public interface IStoreAppService : ICrudAppService<
    StoreDto,
    Guid,
    GetListStoreInput,
    CreateStoreInput,
    UpdateStoreInput>
{
    /// <summary>
    /// 更改门店状态
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newStatus"></param>
    /// <returns></returns>
    Task<StoreDto> ChangeStatusAsync(Guid id, StoreStatus newStatus);

    /// <summary>
    /// 批量删除门店
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task BatchDeleteAsync(List<Guid> ids);
}
