namespace Webshop.Models
{
    public class OrderProducts
    {
        public int Order_id { get; set; }
        public int Product_id { get; set; }
        public int Product_name { get; set; }
        public int Price { get; set; }
    }
}