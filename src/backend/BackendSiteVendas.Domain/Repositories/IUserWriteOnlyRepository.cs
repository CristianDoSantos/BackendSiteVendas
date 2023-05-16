using BackendSiteVendas.Domain.Entities;

namespace BackendSiteVendas.Domain.Repositories;

public interface IUserWriteOnlyRepository
{
    Task Add(User usuario); 
}
