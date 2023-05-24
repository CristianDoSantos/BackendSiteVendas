using AutoMapper;
using BackendSiteVendas.Comunication.Requests;
using BackendSiteVendas.Domain.Entities.User;

namespace BackendSiteVendas.Application.Services.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<UserRegisterRequestJson, User>()
            .ForMember(destiny => destiny.Password, config => config.Ignore());
    }
}
