namespace BackendSiteVendas.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    Task<bool> UserHasEmail(string email);
    Task<Entities.User.User> RetrieveByEmailAndPassword(string email, string password);
    Task<Entities.User.User> RetrieveByEmail(string email);
}
