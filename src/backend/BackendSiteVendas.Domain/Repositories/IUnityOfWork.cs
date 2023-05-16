namespace BackendSiteVendas.Domain.Repositories;

public interface IUnityOfWork
{
    Task Commit();
}