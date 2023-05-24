using BackendSiteVendas.Domain.Entities.Product;
using BackendSiteVendas.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace BackendSiteVendas.Infrastructure.RepositoryAccess;

public class BackendSiteVendasContext : DbContext
{
    public BackendSiteVendasContext(DbContextOptions<BackendSiteVendasContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BackendSiteVendasContext).Assembly);
    }
}
