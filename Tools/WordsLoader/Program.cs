using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WordsLoader;

public class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
            throw new ArgumentException("Path to words file is not provided.");
        
        var pathToWordsFile = args[0];
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = configuration.GetRequiredSection("ConnectionString").Value;

        using var sqlConnection = new SqlConnection(connectionString);
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
            
            sqlCommand.CommandText = GetCommandSqlCommandText(original, translation);
            sqlCommand.ExecuteNonQuery();
        }
    }

    private static string GetCommandSqlCommandText(string original, string translation)
    {
        return $"insert into [CatLang].[dbo].[Words] (Original, Translation) VALUES ('{original}', '{translation}')";
    }
}