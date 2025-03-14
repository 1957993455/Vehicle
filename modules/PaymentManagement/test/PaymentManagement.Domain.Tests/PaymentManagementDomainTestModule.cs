using Volo.Abp.Modularity;

namespace PaymentManagement;

[DependsOn(
    typeof(PaymentManagementDomainModule),
    typeof(PaymentManagementTestBaseModule)
)]
public class PaymentManagementDomainTestModule : AbpModule
{

}
