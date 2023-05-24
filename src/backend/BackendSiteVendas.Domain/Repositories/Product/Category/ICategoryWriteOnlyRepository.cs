namespace BackendSiteVendas.Domain.Repositories.Product.Category;

public interface ICategoryWriteOnlyRepository
{
    Task Register(Entities.Product.Category category);
    Task Delete(long categoryId);
}
