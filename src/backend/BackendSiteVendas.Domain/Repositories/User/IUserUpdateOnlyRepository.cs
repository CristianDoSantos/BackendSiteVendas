namespace BackendSiteVendas.Domain.Repositories.User;

public interface IUserUpdateOnlyRepository
{
    void Update(Entities.User user);
    Task<Entities.User> RetrieveById(long id);
}
