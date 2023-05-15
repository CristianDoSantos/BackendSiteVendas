using Microsoft.Extensions.Configuration;

namespace BackendSiteVendas.Domain.Extension;

public static class RepositoryExtension
{
    public static string GetDatabaseName(this IConfiguration configurationManager)
        => configurationManager.GetConnectionString("DatabaseName");

    public static string GetConnection(this IConfiguration configurationManager)
        => configurationManager.GetConnectionString("ConnectionString");

    public static string GetCompleteConnection(this IConfiguration configurationManager)
    {
        var databaseName = configurationManager.GetDatabaseName();
        var connectionString = configurationManager.GetConnection();

        return $"{connectionString}Database={databaseName}";
    }
}
