using BackendSiteVendas.Comunication.Requests;
using BackendSiteVendas.Comunication.Responses;

namespace BackendSiteVendas.Application.UseCases.Login.DoLogin
{
    public interface ILoginUseCase
    {
        Task<LoginResponseJson> Execute(LoginRequestJson request);
    }
}
