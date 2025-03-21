using System;
using System.Threading.Tasks;
using Vehicle.App.Domain.ValueObjects;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Vehicle.App.Domain.Store;

public class StoreManager : DomainService
{
    private readonly IRepository<StoreAggregateRoot, Guid> _storeRepository;

    public StoreManager(IRepository<StoreAggregateRoot, Guid> storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<StoreAggregateRoot> CreateAsync(
        string name,
        string storeCode,
        AddressValueObject fullAddress,
        GeoLocationValueObject location)
    {
        // 检查编码唯一性
        if (await _storeRepository.AnyAsync(x => x.StoreCode == storeCode))
        {
            throw new BusinessException("Store:CodeAlreadyExists");
        }

        return new StoreAggregateRoot(
            name,
            storeCode,
            fullAddress,
            location
           );
    }

    protected string GenerateStoreCode(AddressValueObject address)
    {
        return string.Empty;
    }

}
