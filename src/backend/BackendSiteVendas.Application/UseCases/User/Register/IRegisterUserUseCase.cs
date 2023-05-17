using BackendSiteVendas.Comunication.Requests;
using BackendSiteVendas.Comunication.Responses;

namespace BackendSiteVendas.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task<RegisteredUserResponseJson> Execute(UserRegisterRequestJson request);
}
