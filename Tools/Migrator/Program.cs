using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Migrator;

public class Program
{
    private enum DatabaseType
    {
        SqlServer,
        PostgreSql
    }

    private static DatabaseType databaseType = DatabaseType.PostgreSql;
    
    private static void Main(string[] args)
    {
        if (args.Length == 0)
            throw new ArgumentException("Path to scripts file is not provided.");

        var sqlScriptsFilePaths = Directory
            .GetFiles(args[0])
            .ToDictionary(path => int.Parse(Path.GetFileName(path).Split(".").First()));
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionStringConfigurationSection = databaseType == DatabaseType.SqlServer
            ? "SqlServerConnectionString"
            : "PostgreSqlConnectionString";
        var connectionString = configuration.GetRequiredSection(connectionStringConfigurationSection).Value;
        using var sqlConnection = databaseType == DatabaseType.SqlServer
            ? GetSqlServerConnection(connectionString)
            : GetPostgreSqlServerConnection(connectionString);
        sqlConnection.Open();

        var currentVersion = GetCurrentDatabaseVersion(sqlConnection);
        if (currentVersion == null)
        {
            var createDdbMigrationsScript = GetScript(sqlScriptsFilePaths[0]);
            ExecuteScript(sqlConnection, createDdbMigrationsScript);
            currentVersion = 0;
        }

        var versions = sqlScriptsFilePaths.Keys.OrderBy(k => k).Where(v => v > currentVersion).ToList();
        foreach (var version in versions)
        {
            Console.WriteLine($"Migrate to version {version}...");
            
            var migrationScript = GetScript(sqlScriptsFilePaths[version]);
            ExecuteScript(sqlConnection, migrationScript);
            UpdateDatabaseVersion(sqlConnection, version);
            
            Console.WriteLine($"Successfully migrated to version {version}.");
        }
    }

    private static DbConnection GetSqlServerConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }
    
    private static DbConnection GetPostgreSqlServerConnection(string connectionString)
    {
        return new NpgsqlConnection(connectionString);
    }

    private static string GetCurrentDatabaseVersionPostgreSqlScript =
        "SELECT \"Version\" FROM public.\"DatabaseMigrations\" ORDER BY \"Version\" DESC LIMIT 1";

    private static string GetCurrentDatabaseVersionSqlServerScript = 
        @" select top (1) [Version] from [CatLang].[dbo].[DatabaseMigrations] order by [Id] desc";
    
    private static int? GetCurrentDatabaseVersion(DbConnection connection)
    {
        try
        {
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = databaseType == DatabaseType.SqlServer
                ? GetCurrentDatabaseVersionSqlServerScript
                : GetCurrentDatabaseVersionPostgreSqlScript;
            var version = (int) sqlCommand.ExecuteScalar();
            return version;
        }
        catch
        {
            return null;
        }
    }

    private static string GetScript(string pathToScript)
    {
        using var reader = new StreamReader(pathToScript);
        var script = reader.ReadToEnd();
        return script;
    }

    private static void ExecuteScript(DbConnection connection, string script)
    {
        var sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = script;
        sqlCommand.ExecuteNonQuery();
    }

    private static void UpdateDatabaseVersion(DbConnection connection, int version)
    {
        var currentDate = DateTime.Now;
        var sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = databaseType == DatabaseType.SqlServer
            ? GetSqlServerUpdateDatabaseVersionCommand(version, currentDate)
            : GetPostgreSqlUpdateDatabaseVersionCommand(version, currentDate);
        sqlCommand.ExecuteNonQuery();
    }

    private static string GetSqlServerUpdateDatabaseVersionCommand(int version, DateTime currentDate)
    {
        return $"insert into [CatLang].[dbo].[DatabaseMigrations] (Date, Version) values ('{currentDate}', '{version}')";
    }

    private static string GetPostgreSqlUpdateDatabaseVersionCommand(int version, DateTime currentDate)
    {
        return $"INSERT INTO public.\"DatabaseMigrations\"(\"Version\", \"Date\") VALUES ({version}, '{currentDate}')";
    }
}
