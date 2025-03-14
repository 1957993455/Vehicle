﻿using Volo.Abp.Modularity;

namespace AuditLogManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class AuditLogManagementApplicationTestBase<TStartupModule> : AuditLogManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
