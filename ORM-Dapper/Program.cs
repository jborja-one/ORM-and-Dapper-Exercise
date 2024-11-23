using System.Data;
using Microsoft.Extensions.Configuration;using MySql.Data.MySqlClient;namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection connection = new MySqlConnection(connString);

            var repo = new DapperProductRepository(connection);
            var products = repo.GetAllProducts();

            foreach(var prod in products)            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");
            }
        }
    }
}
