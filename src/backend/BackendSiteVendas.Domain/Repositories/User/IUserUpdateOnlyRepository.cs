namespace BackendSiteVendas.Domain.Repositories.User;

public interface IUserUpdateOnlyRepository
{
    void Update(Entities.User.User user);
    Task<Entities.User.User> RetrieveById(long id);
}
