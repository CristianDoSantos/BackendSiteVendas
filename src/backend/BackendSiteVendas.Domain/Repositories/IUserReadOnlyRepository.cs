namespace BackendSiteVendas.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    Task<bool> UserHasEmail(string email);
}
