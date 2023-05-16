using BackendSiteVendas.Domain.Repositories;

namespace BackendSiteVendas.Infrastructure.RepositoryAccess;

public sealed class UnityOfWork : IDisposable, IUnityOfWork
{
    private readonly BackendSiteVendasContext _context;
    private bool _disposed;

    public UnityOfWork(BackendSiteVendasContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }

}