using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace PaymentManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PaymentManagementDomainSharedModule)
)]
public class PaymentManagementDomainModule : AbpModule
{

}
