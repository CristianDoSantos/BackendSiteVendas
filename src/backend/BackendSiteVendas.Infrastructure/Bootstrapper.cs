using BackendSiteVendas.Domain.Extension;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackendSiteVendas.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigrator(services, configurationManager);
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c => c.AddSqlServer()
        .WithGlobalConnectionString(configurationManager.GetCompleteConnection()).ScanIn(Assembly.Load("BackendSiteVendas.Infrastructure")).For.All());
    }
}
