using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Webshop.Models;

namespace Webshop.Repositories
{
    public class WebshopRepository
    {
        private string connectionString;

        public  WebshopRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Items> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var news = connection.Query<Items>("SELECT * FROM News").ToList();
                return news;
            }
        }

        public Items Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var newsItem = connection.QuerySingleOrDefault<Items>("SELECT * FROM News WHERE Id = @id", new { id });
                return newsItem;
            };
        }

        public void Add(Items items)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO News (Header, Body) VALUES(@header, @body)", items);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM News WHERE Id = @id", new { id });
                
            };
        }

    }
    }
}