using BackendSiteVendas.Domain.Repositories;
using Moq;

namespace UtilitiesForTests.Repositories;

public class UserReadOnlyRepositoryBuilder
{
    private static UserReadOnlyRepositoryBuilder _instance;
    private readonly Mock<IUserReadOnlyRepository> _repository;

    private UserReadOnlyRepositoryBuilder()
    {
        if (_repository is null)
        {
            _repository= new Mock<IUserReadOnlyRepository>();
        }
    }
    public static UserReadOnlyRepositoryBuilder Instance()
    {
        _instance = new UserReadOnlyRepositoryBuilder();
        return _instance;
    }

    public UserReadOnlyRepositoryBuilder ExistUserWithEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
            _repository.Setup(i => i.UserHasEmail(email)).ReturnsAsync(true);

        return this;
    }

    public UserReadOnlyRepositoryBuilder RetrieveByEmailAndPassword(BackendSiteVendas.Domain.Entities.User user)
    {
        _repository.Setup(i => i.RetrieveByEmailAndPassword(user.Email, user.Password)).ReturnsAsync(user);

        return this;
    }

    public IUserReadOnlyRepository Build()
    {
        return _repository.Object;
    }
}
