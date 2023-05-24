using BackendSiteVendas.Application.Services.LoggedUser;
using BackendSiteVendas.Domain.Entities.User;
using Moq;

namespace UtilitiesForTests.LoggedUser;

public class LoggedUserBuilder
{
    private static LoggedUserBuilder _instance;
    private readonly Mock<ILoggedUser> _repository;

    private LoggedUserBuilder()
    {
        if (_repository is null)
        {
            _repository = new Mock<ILoggedUser>();
        }
    }

    public static LoggedUserBuilder Instance()
    {
        _instance = new LoggedUserBuilder();
        return _instance;
    }

    public LoggedUserBuilder RetrieveUser(User user)
    {
        _repository.Setup(c => c.RetrieveUser()).ReturnsAsync(user);

        return this;
    }

    public ILoggedUser Build()
    {
        return _repository.Object;
    }
}
