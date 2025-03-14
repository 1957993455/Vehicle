﻿using Volo.Abp.Modularity;

namespace PaymentManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class PaymentManagementApplicationTestBase<TStartupModule> : PaymentManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
