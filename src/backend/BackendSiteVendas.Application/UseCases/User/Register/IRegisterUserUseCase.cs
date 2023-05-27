using BackendSiteVendas.Comunication.Requests.User;
using BackendSiteVendas.Comunication.Responses.User;

namespace BackendSiteVendas.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task<RegisteredUserResponseJson> Execute(UserRegisterRequestJson request);
}
