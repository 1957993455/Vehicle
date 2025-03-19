using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.App.Enums;
using Vehicle.App.Vehicle;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Vehicle.App.EntityFrameworkCore.Repositories;

/// <summary>
/// 车辆仓储实现
/// </summary>
public class EfCoreVehicleRepository : EfCoreRepository<AppDbContext, VehicleAggregateRoot, Guid>, IVehicleRepository
{
    public EfCoreVehicleRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<VehicleAggregateRoot>> GetListAsync(int skipCount = 0, int maxResultCount = int.MinValue, string? sorting = null, string? filter = null, bool includeDetails = false, VehicleStatus? status = null, CancellationToken cancellationToken = default)
    {
        var query = await GetFilteredQueryableAsync(filter, includeDetails, status);

        return await query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? "Id" : sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    protected async Task<IQueryable<VehicleAggregateRoot>> GetFilteredQueryableAsync(string? filter, bool includeDetails, VehicleStatus? status)
    {
        var query = await GetQueryableAsync();

        return query.WhereIf(!string.IsNullOrWhiteSpace(filter), x => filter != null && x.VIN.Contains(filter))
                       .WhereIf(status.HasValue, x => x.Status == status.Value);
    }
}
