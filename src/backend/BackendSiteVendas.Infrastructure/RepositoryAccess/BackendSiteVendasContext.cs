using BackendSiteVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendSiteVendas.Infrastructure.RepositoryAccess;

public class BackendSiteVendasContext : DbContext
{
    public BackendSiteVendasContext(DbContextOptions<BackendSiteVendasContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BackendSiteVendasContext).Assembly);
    }
}
