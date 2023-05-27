using BackendSiteVendas.Comunication.Requests.Login.DoLogin;
using BackendSiteVendas.Comunication.Responses.Login.DoLogin;

namespace BackendSiteVendas.Application.UseCases.Login.DoLogin
{
    public interface ILoginUseCase
    {
        Task<LoginResponseJson> Execute(LoginRequestJson request);
    }
}
