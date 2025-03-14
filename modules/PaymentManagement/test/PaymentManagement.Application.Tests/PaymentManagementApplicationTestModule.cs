using Volo.Abp.Modularity;

namespace PaymentManagement;

[DependsOn(
    typeof(PaymentManagementApplicationModule),
    typeof(PaymentManagementDomainTestModule)
    )]
public class PaymentManagementApplicationTestModule : AbpModule
{

}
