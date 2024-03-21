using System.Data.SqlClient;

namespace WorkingWithADatabase;

class Program
{
    public static void Main(string[] args)
    {
        string server = "127.0.0.1,1433";
        string database = "PublishingHouse";
        string username = "SA";
        // string password = "P455word";
        string password = Environment.GetEnvironmentVariable("pwd").ToString();

        var connectionString = $"Server ={server};TrustServerCertificate=True;Database={database};User Id={username};Password={password};";
        var sql = "insert into books values (10,'Dune','original',null,null,null)";
        var conn = new SqlConnection(connectionString);

        // Console.WriteLine(conn);
        conn.Open();
        var cmd = new SqlCommand(sql, conn);  // create a command object
        var reader = cmd.ExecuteReader(); // execute the sql command a get a reader
        while (reader.Read())
        {
            Console.WriteLine($"{reader["Title"]}");
        }
        reader.Close();
        conn.Close();
    }
}
