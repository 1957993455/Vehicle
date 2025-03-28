﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Vehicle.App.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Vehicle.App.EntityFrameworkCore.EntityFrameworkCore;

public class EntityFrameworkCoreAppDbSchemaMigrator
    : IAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAppDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AppDbContext>()
            .Database
            .MigrateAsync();
    }
}
