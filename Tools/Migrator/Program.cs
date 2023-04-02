using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Migrator;

public class Program
{
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
        
        var connectionString = configuration.GetRequiredSection("ConnectionString").Value;
        using var sqlConnection = new SqlConnection(connectionString);
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

    private static int? GetCurrentDatabaseVersion(SqlConnection connection)
    {
        try
        {
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = @"select top (1) [Version]
            from [CatLang].[dbo].[DatabaseMigrations]
            order by [Id] desc";
            var version = (int) sqlCommand.ExecuteScalar();
            return version;
        }
        catch (Exception e)
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

    private static void ExecuteScript(SqlConnection connection, string script)
    {
        var sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = script;
        sqlCommand.ExecuteNonQuery();
    }

    private static void UpdateDatabaseVersion(SqlConnection connection, int version)
    {
        var currentDate = DateTime.Now;
        var sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = $"insert into [CatLang].[dbo].[DatabaseMigrations] (Date, Version) values ('{currentDate}', '{version}')";
        sqlCommand.ExecuteNonQuery();
    }
}
