using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace PaymentManagement;

[DependsOn(
    typeof(PaymentManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PaymentManagementApplicationContractsModule : AbpModule
{

}
