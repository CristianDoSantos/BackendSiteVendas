namespace BackendSiteVendas.Application.Services.LoggedUser;

public interface ILoggedUser
{
    Task<Domain.Entities.User> RetrieveUser();
}
