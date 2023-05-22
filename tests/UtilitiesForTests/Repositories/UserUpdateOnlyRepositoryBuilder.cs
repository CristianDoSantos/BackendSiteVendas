using BackendSiteVendas.Domain.Repositories.User;
using Moq;

namespace UtilitiesForTests.Repositories;

public class UserUpdateOnlyRepositoryBuilder
{
    private static UserUpdateOnlyRepositoryBuilder _instance;
    public readonly Mock<IUserUpdateOnlyRepository> _repository;

    private UserUpdateOnlyRepositoryBuilder()
    {
        if (_repository is null)
        {
            _repository = new Mock<IUserUpdateOnlyRepository>();
        }
    }

    public static UserUpdateOnlyRepositoryBuilder Instance()
    {
        _instance = new UserUpdateOnlyRepositoryBuilder();
        return _instance;
    }

    public UserUpdateOnlyRepositoryBuilder RetrieveById(BackendSiteVendas.Domain.Entities.User user)
    {
        _repository.Setup(c => c.RetrieveById(user.Id)).ReturnsAsync(user);

        return this;
    }

    public IUserUpdateOnlyRepository Build()
    {
        return _repository.Object;
    }
}
