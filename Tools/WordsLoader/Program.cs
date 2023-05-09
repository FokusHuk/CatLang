using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace WordsLoader;

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
            throw new ArgumentException("Path to words file is not provided.");
        
        var pathToWordsFile = args[0];
        
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

        var sqlCommand = sqlConnection.CreateCommand();

        using var reader = new StreamReader(pathToWordsFile);
        while (!reader.EndOfStream)
        {
            var original = reader.ReadLine();
            var translation = reader.ReadLine();

            if (original is null || translation is null)
            {
                throw new InvalidOperationException("Null arguments for the new words were provided.");
            }
            
            sqlCommand.CommandText = databaseType == DatabaseType.SqlServer
                ? GetSqlServerCommandText(original, translation)
                : GetPostgreSqlCommandText(original, translation);
            sqlCommand.ExecuteNonQuery();
        }
    }

    private static string GetSqlServerCommandText(string original, string translation)
    {
        return $"insert into [CatLang].[dbo].[Words] (Original, Translation) VALUES ('{original}', '{translation}')";
    }

    private static string GetPostgreSqlCommandText(string original, string translation)
    {
        return $"INSERT INTO public.\"Words\"(\"Original\", \"Translation\") VALUES ('{original}', '{translation}')";
    }

    private static DbConnection GetSqlServerConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }

    private static DbConnection GetPostgreSqlServerConnection(string connectionString)
    {
        return new NpgsqlConnection(connectionString);
    }
}
