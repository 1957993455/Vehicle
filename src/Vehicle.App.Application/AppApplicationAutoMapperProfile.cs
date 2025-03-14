using AutoMapper;
using Volo.Abp.Identity;

namespace Vehicle.App;

public class AppApplicationAutoMapperProfile : Profile
{
    public AppApplicationAutoMapperProfile()
    {
        CreateMap<IdentityUser, IdentityUserDto>()
           .MapExtraProperties();
    }
}
