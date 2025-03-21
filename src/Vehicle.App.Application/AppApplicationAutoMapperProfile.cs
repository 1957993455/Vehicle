using AutoMapper;
using Vehicle.App.Application.Contracts.Order.Dtos;
using Vehicle.App.Application.Contracts.Organization.Dtos;
using Vehicle.App.Application.Contracts.Store.Dtos;
using Vehicle.App.Application.Contracts.Vehicle.Dtos;
using Vehicle.App.Domain.Order;
using Vehicle.App.Domain.Store;
using Vehicle.App.Domain.Vehicle;
using Volo.Abp.Identity;

namespace Vehicle.App.Application;

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
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));
        CreateMap<CreateStoreInput, StoreAggregateRoot>();
        CreateMap<UpdateStoreInput, StoreAggregateRoot>();
        CreateMap<OrderAggregateRoot, OrderDto>();
        CreateMap<CreateOrderInput, OrderAggregateRoot>();
        CreateMap<UpdateOrderInput, OrderAggregateRoot>();
        //        UpdateVehicleDto->VehicleAggregateRoot
        //Vehicle.App.Vehicle.Dtos.UpdateVehicleDto->Vehicle.App.Vehicle.VehicleAggregateRoot

        CreateMap<CreateVehicleInput, VehicleAggregateRoot>();
        CreateMap<UpdateVehicleInput, VehicleAggregateRoot>();



    }
}
