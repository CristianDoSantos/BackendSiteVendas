using BackendSiteVendas.Comunication.Requests.User;

namespace BackendSiteVendas.Application.UseCases.User.ChangePassword;

public interface IChangePasswordUseCase
{
    Task Execute(ChangePasswordRequestJson request);
}
