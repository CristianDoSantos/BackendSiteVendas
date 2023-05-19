using BackendSiteVendas.Infrastructure.RepositoryAccess;
using UtilitiesForTests.Entities;

namespace WebApi.Tests;

public class ContextSeedInMemory
{
    public static (BackendSiteVendas.Domain.Entities.User user, string password) Seed(BackendSiteVendasContext context)
    {
        (var user, var password) = UserBuilder.Build();

        context.Users.Add(user);

        context.SaveChanges();

        return (user, password);
    }
}
