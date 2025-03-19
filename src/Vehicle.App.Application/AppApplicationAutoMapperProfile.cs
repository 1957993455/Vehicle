using AutoMapper;
using Vehicle.App.Order;
using Vehicle.App.Order.Dtos;
using Vehicle.App.Organization.Dtos;
using Vehicle.App.Store;
using Vehicle.App.Store.Dtos;
using Vehicle.App.Vehicle;
using Vehicle.App.Vehicle.Dtos;
using Volo.Abp.Identity;

namespace Vehicle.App;

public class AppApplicationAutoMapperProfile : Profile
{
    public AppApplicationAutoMapperProfile()
    {
        CreateMap<IdentityUser, IdentityUserDto>()
           .MapExtraProperties();
        CreateMap<VehicleAggregateRoot, VehicleDto>();
        CreateMap<MaintenanceRecordEntity, MaintenanceRecordDto>();
        CreateMap<OrganizationUnit, OrganizationUnitDto>().ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime));
        CreateMap<CreateOrganizationUnitInput, OrganizationUnit>();
        CreateMap<UpdateOrganizationUnitInput, OrganizationUnit>();
        CreateMap<VehiclePurchaseRecordEntity, VehiclePurchaseRecordDto>();
        CreateMap<CreateVehiclePurchaseRecordDto, VehiclePurchaseRecordEntity>();
        CreateMap<UpdateVehiclePurchaseRecordDto, VehiclePurchaseRecordEntity>();
        CreateMap<StoreAggregateRoot, StoreDto>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Address.Province))
            .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Address.Detail))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));
        CreateMap<CreateStoreInput, StoreAggregateRoot>();
        CreateMap<UpdateStoreInput, StoreAggregateRoot>();
        CreateMap<OrderAggregateRoot, OrderDto>();
        CreateMap<CreateOrderInput, OrderAggregateRoot>();
        CreateMap<UpdateOrderInput, OrderAggregateRoot>();
    }
}
