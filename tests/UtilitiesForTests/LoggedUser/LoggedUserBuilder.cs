using BackendSiteVendas.Application.Services.LoggedUser;
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

    public LoggedUserBuilder RetrieveUser(BackendSiteVendas.Domain.Entities.User user)
    {
        _repository.Setup(c => c.RetrieveUser()).ReturnsAsync(user);

        return this;
    }

    public ILoggedUser Build()
    {
        return _repository.Object;
    }
}
