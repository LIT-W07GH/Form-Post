using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class NorthwindDb
    {
        private string _connectionString;

        public NorthwindDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> SearchProducts(int minStock, int maxStock)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE UnitsInStock BETWEEN @min AND @max";
            cmd.Parameters.AddWithValue("@min", minStock);
            cmd.Parameters.AddWithValue("@max", maxStock);
            connection.Open();
            List<Product> results = new List<Product>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    Name = (string)reader["ProductName"],
                    Price = (decimal)reader["UnitPrice"],
                    UnitsInStock = reader.GetOrNull<short>("UnitsInStock"),
                    QuantityPerUnit = reader.GetOrNull<string>("QuantityPerUnit")
                });
            }
            connection.Close();
            connection.Dispose();
            return results;
        }
    }
}
