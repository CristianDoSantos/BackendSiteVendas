using AutoMapper;
using BackendSiteVendas.Comunication.Requests;

namespace BackendSiteVendas.Application.Services.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<UserRegisterRequestJson, Domain.Entities.User>()
            .ForMember(destiny => destiny.Password, config => config.Ignore());
    }
}
