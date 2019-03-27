using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Webshop.Models;

namespace Webshop.Repositories
{
    public class OrderRepository
    {
        private string connectionString;

        public  OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Orders> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var allOrders = connection.Query<Orders>("SELECT * FROM orders").ToList();
                return allOrders;
            }
        }

        public Orders Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var orders = connection.QuerySingleOrDefault<Orders>("SELECT * FROM orders WHERE Id = @id", new { id });
                return orders;
            };
        }

        public void Add(Orders orders)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO orders (name, street_adress, postal_code, city, country, email, phone_number) VALUES(@header, @body)", orders);
                connection.Execute("INSERT INTO order_products (order_id, product_id, product_name, quantity, price) VALUES ()");
            }
        }
    }
}