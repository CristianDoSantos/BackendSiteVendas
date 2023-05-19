using BackendSiteVendas.Infrastructure.RepositoryAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Tests
{
    public class BackendSiteVendasWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private BackendSiteVendas.Domain.Entities.User _user;
        private string _password;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test").ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(BackendSiteVendasContext));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<BackendSiteVendasContext>(options => {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(provider);
                });

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var scopeService = scope.ServiceProvider;

                var database = scopeService.GetRequiredService<BackendSiteVendasContext>();

                database.Database.EnsureDeleted();

                (_user, _password) = ContextSeedInMemory.Seed(database);
            });
        }

        public BackendSiteVendas.Domain.Entities.User RetrieveUser()
        {
            return _user;
        }

        public string RetrievePassword()
        {
            return _password;
        }
    }
}
