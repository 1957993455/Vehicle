using System;
using Vehicle.App.Order;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Vehicle.App.EntityFrameworkCore.Repositories;

public class EfCoreOrderRepository : EfCoreRepository<AppDbContext, OrderAggregateRoot, Guid>, IOrderRepository
{
    public EfCoreOrderRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }



}
