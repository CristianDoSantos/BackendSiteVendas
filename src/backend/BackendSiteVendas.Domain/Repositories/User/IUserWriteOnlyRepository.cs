namespace BackendSiteVendas.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    Task Register(Entities.User.User user);
}
