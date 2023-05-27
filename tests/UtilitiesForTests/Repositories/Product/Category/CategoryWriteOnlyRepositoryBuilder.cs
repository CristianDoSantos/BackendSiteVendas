using BackendSiteVendas.Domain.Repositories.Product.Category;
using Moq;

namespace UtilitiesForTests.Repositories.Product.Category;

public class CategoryWriteOnlyRepositoryBuilder
{
    private static CategoryWriteOnlyRepositoryBuilder _instance;
    private readonly Mock<ICategoryWriteOnlyRepository> _repository;

    private CategoryWriteOnlyRepositoryBuilder()
    {
        if (_repository is null)
        {
            _repository= new Mock<ICategoryWriteOnlyRepository>();
        }
    }

    public static CategoryWriteOnlyRepositoryBuilder Instance()
    {
        _instance = new CategoryWriteOnlyRepositoryBuilder();
        return _instance;
    }

    public ICategoryWriteOnlyRepository Build()
    {
        return _repository.Object;
    }
}
