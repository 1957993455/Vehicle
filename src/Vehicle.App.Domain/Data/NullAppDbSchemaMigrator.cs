﻿using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Vehicle.App.Domain.Data;

/* This is used if database provider does't define
 * IAppDbSchemaMigrator implementation.
 */
public class NullAppDbSchemaMigrator : IAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
