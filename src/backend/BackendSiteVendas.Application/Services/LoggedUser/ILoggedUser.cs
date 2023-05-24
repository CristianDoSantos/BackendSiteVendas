using BackendSiteVendas.Domain.Entities.User;

namespace BackendSiteVendas.Application.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> RetrieveUser();
}
