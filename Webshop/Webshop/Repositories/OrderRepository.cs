using System;
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
                var allOrders = connection.Query<Orders>("SELECT orders.customer_name, orders.street_adress, orders.postal_code, orders.city, orders.country, orders.email, orders.phone_number, order_products.product_name, order_products.price FROM orders INNER JOIN order_products ON orders.id=order_products.order_id").ToList();
                return allOrders;
            }
        }

        public Orders Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var orders = connection.QuerySingleOrDefault<Orders>("SELECT * FROM orders INNER JOIN order_products ON orders.id=order_products.order_id WHERE Id = @id", new { id });
                return orders;
            };
        }

        public void Add(List<CartProduct> products, Customer customer)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var orderId = connection.QuerySingle<int>("INSERT INTO orders (customer_name, street_adress, postal_code, city, country, email, phone_number) VALUES(@customer_name, @street_adress, @postal_code, @city, @country, @email, @phone_number); SELECT LAST_INSERT_ID()", customer);
                foreach (var product in products)
                {
                    connection.Execute(
                        "INSERT INTO order_products (order_id, product_id, product_name, price) VALUES (@order_id, @product_id, @product_name, @price)",
                        new{order_id=orderId, product_id=product.Id, product_name=product.Name, price=product.Price});
                }

            }
        }
    }
}