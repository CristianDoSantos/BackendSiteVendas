using AutoMapper;
using BackendSiteVendas.Comunication.Requests.User;
using BackendSiteVendas.Domain.Entities.User;
using HashidsNet;

namespace BackendSiteVendas.Application.Services.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    private readonly IHashids _hashids;

    public AutoMapperConfiguration(IHashids hashids)
    {
        _hashids = hashids;

        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<UserRegisterRequestJson, User>()
            .ForMember(destiny => destiny.Password, config => config.Ignore());

        CreateMap<Comunication.Requests.Product.CategoryRegisterRequestJson, Domain.Entities.Product.Category>();
    }

    private void EntityToResponse()
    {
        CreateMap<Domain.Entities.Product.Category, Comunication.Responses.Poduct.ProductCategoryRegisterResponseJson> ();
    }
}
