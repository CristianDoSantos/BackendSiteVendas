using BackendSiteVendas.Comunication.Requests;

namespace BackendSiteVendas.Application.UseCases.User.ChangePassword;

public interface IChangePasswordUseCase
{
    Task Execute(ChangePasswordRequestJson request);
}
