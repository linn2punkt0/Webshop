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

        public Carts Get(int cart_id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var carts = connection.QuerySingleOrDefault<Carts>("SELECT * FROM carts WHERE cart_id = @cart_id", new { cart_id });
                return carts;
            };
        }

        public void Add(Carts carts)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO carts (cart_id, product_id) VALUES(@cart_id, @product_id)", carts);
            }
        }
        public void Delete(int cart_id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM carts WHERE cart_id = @cart_id", new { cart_id });
                
            };
        }
    }
}