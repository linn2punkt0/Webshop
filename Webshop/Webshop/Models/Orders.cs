using System.Collections.Generic;

namespace Webshop.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        public string Date { get; set; }
        public List<OrderProducts> Products;
    
    }
}