using BackendSiteVendas.Domain.Extension;
using BackendSiteVendas.Domain.Repositories;
using BackendSiteVendas.Infrastructure.RepositoryAccess;
using BackendSiteVendas.Infrastructure.RepositoryAccess.Repository;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackendSiteVendas.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigrator(services, configurationManager);

        AddContext(services, configurationManager);
        AddUnityOfWork(services);
        AddRepositories(services);
    }

    private static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {
        var connectionString = configurationManager.GetCompleteConnection();

        services.AddDbContext<BackendSiteVendasContext>(dbContextOptions => 
        {
            dbContextOptions.UseSqlServer(connectionString);
        });
    }

    private static void AddUnityOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UserRepository>()
            .AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c => c.AddSqlServer()
        .WithGlobalConnectionString(configurationManager.GetCompleteConnection()).ScanIn(Assembly.Load("BackendSiteVendas.Infrastructure")).For.All());
    }
}
