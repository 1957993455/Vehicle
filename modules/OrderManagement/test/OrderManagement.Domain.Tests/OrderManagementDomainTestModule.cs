using Volo.Abp.Modularity;

namespace OrderManagement;

[DependsOn(
    typeof(OrderManagementDomainModule),
    typeof(OrderManagementTestBaseModule)
)]
public class OrderManagementDomainTestModule : AbpModule
{

}
