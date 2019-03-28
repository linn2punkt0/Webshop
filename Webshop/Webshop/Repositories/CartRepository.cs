using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Webshop.Models;
namespace Webshop.Repositories
{
    public class CartRepository
    {
        private string connectionString;

        public  CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Carts> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var allCarts = connection.Query<Carts>("SELECT * FROM carts").ToList();
                return allCarts;
            }
        }

        public Carts Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var carts = connection.QuerySingleOrDefault<Carts>("SELECT * FROM carts WHERE Id = @id", new { id });
                return carts;
            };
        }

        public void Add(Carts carts)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO carts (id, product_id, quantity) VALUES(@id, @product_id, @quantity)", carts);
            }
        }
    }
}