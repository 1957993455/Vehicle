using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.App.Application.Contracts.Store;
using Vehicle.App.Application.Contracts.Store.Dtos;
using Vehicle.App.Domain.Shared.Enums;
using Vehicle.App.Domain.Store;
using Vehicle.App.Domain.ValueObjects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Vehicle.App.Application.Store;

/// <summary>
/// 门店应用服务
/// </summary>
public class StoreAppService :
    CrudAppService<
        StoreAggregateRoot,
        StoreDto,
        Guid,
        GetListStoreInput,
        CreateStoreInput,
        UpdateStoreInput>,
    IStoreAppService
{
    private readonly StoreManager _storeManager;
    protected IRepository<IdentityUser, Guid> UserRepository { get; }

    public StoreAppService(
        IRepository<StoreAggregateRoot, Guid> repository,
        StoreManager storeManager,
        IRepository<IdentityUser, Guid> userRepository)
        : base(repository)
    {
        _storeManager = storeManager;
        UserRepository = userRepository;
    }

    public override async Task<StoreDto> CreateAsync(CreateStoreInput input)
    {
        var location = new GeoLocationValueObject(input.Longitude ?? "", input.Latitude ?? "");
        var address = new AddressValueObject(input.Province, input.City, input.District, input.Street, input.DetailAddress, input.Level, input.AdCode, input.Longitude, input.Latitude);
        var store = await _storeManager.CreateAsync(
            input.Name,
            input.StoreCode,
            address,
            location
           );

        await Repository.InsertAsync(store);
        return ObjectMapper.Map<StoreAggregateRoot, StoreDto>(store);
    }

    public async Task<StoreDto> ChangeStatusAsync(Guid id, StoreStatus newStatus)
    {
        var store = await Repository.GetAsync(id);
        store.ChangeStatus(newStatus);
        await Repository.UpdateAsync(store);
        return ObjectMapper.Map<StoreAggregateRoot, StoreDto>(store);
    }

    protected override async Task<IQueryable<StoreAggregateRoot>> CreateFilteredQueryAsync(GetListStoreInput input)
    {
        var query = await base.CreateFilteredQueryAsync(input);

        return query.WhereIf(input.Status.HasValue, x => input.Status.HasValue && x.Status == input.Status.Value)
           .WhereIf(!string.IsNullOrEmpty(input.Name), x => input.Name != null && x.Name.Contains(input.Name));
    }

    public override async Task<PagedResultDto<StoreDto>> GetListAsync(GetListStoreInput input)
    {
        PagedResultDto<StoreDto> result = await base.GetListAsync(input);
        //����id����ѯ��������Ϣ

        var managerIds = result.Items.Select(x => x.ManagerId).Distinct();

        var manangerNames = await UserRepository.GetListAsync(x => managerIds.Contains(x.Id));

        foreach (var item in result.Items)
        {
            var manager = manangerNames.FirstOrDefault(x => x.Id == item.ManagerId);

            if (manager == null)
            {
                item.ManagerName = "δ֪";
                item.ManagerPhone = "δ֪";
                continue;
            }

            item.ManagerName = manager.UserName;
            item.ManagerPhone = manager.PhoneNumber;
        }

        return result;
    }

    /// <summary>
    /// 批量删除门店
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task BatchDeleteAsync(List<Guid> ids)
    {
        var stores = await Repository.GetListAsync(x => ids.Contains(x.Id));
        await Repository.DeleteManyAsync(stores);
    }
}
