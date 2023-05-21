using BackendSiteVendas.Domain.Entities;

namespace BackendSiteVendas.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    Task Add(Entities.User user);
}
