using BackendSiteVendas.Domain.Repositories.User;
using Moq;

namespace UtilitiesForTests.Repositories;

public class UserWriteOnlyRepositoryBuilder
{
    private static UserWriteOnlyRepositoryBuilder _instace;
    private readonly Mock<IUserWriteOnlyRepository> _repository;

    private UserWriteOnlyRepositoryBuilder()
    {
        if (_repository is null)
        {
            _repository= new Mock<IUserWriteOnlyRepository>();
        }
    }

    public static UserWriteOnlyRepositoryBuilder Instance()
    {
        _instace= new UserWriteOnlyRepositoryBuilder();
        return _instace;
    }

    public IUserWriteOnlyRepository Build()
    {
        return _repository.Object;
    }
}
