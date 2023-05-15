using System.Data.SqlClient;

namespace BackendSiteVendas.Infrastructure.Migrations;

public static class Database
{
    public static void CreateDatabase(string connectionString, string databaseName)
    {
        string CHECK_DATABASE_QUERY = "SELECT COUNT(*) FROM sys.databases WHERE name = @DatabaseName";

        using SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        using SqlCommand checkDatabaseCommand = new SqlCommand(CHECK_DATABASE_QUERY, myConnection);
        checkDatabaseCommand.Parameters.AddWithValue("@DatabaseName", databaseName);
        int databaseExists = (int)checkDatabaseCommand.ExecuteScalar();

        if (databaseExists == 0)
        {
            string createDatabaseQuery = $"CREATE DATABASE [{databaseName}]";
            using SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseQuery, myConnection);
            createDatabaseCommand.ExecuteNonQuery();
        }
    }
}