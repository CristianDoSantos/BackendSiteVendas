using BackendSiteVendas.Domain.Repositories;
using Moq;

namespace UtilitiesForTests.Repositories;

public class UnityOfWorkBuilder
{
    private static UnityOfWorkBuilder _instance;
    private readonly Mock<IUnityOfWork> _repository;

    private UnityOfWorkBuilder()
    {
        if (_repository is null)
        {
            _repository= new Mock<IUnityOfWork>();
        }
    }

    public static UnityOfWorkBuilder Instance()
    {
        _instance= new UnityOfWorkBuilder();
        return _instance;
    }

    public IUnityOfWork Build()
    {
        return _repository.Object;
    }
}
