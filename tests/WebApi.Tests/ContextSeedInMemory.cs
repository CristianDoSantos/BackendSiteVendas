using BackendSiteVendas.Domain.Entities.User;
using BackendSiteVendas.Infrastructure.RepositoryAccess;
using UtilitiesForTests.Entities;

namespace WebApi.Tests;

public class ContextSeedInMemory
{
    public static (User user, string password) Seed(BackendSiteVendasContext context)
    {
        (var user, var password) = UserBuilder.Build();

        context.Users.Add(user);

        context.SaveChanges();

        return (user, password);
    }
}
