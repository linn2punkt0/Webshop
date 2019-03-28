namespace Webshop.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string Customer_name { get; set; }
        public string Street_adress { get; set; }
        public string Postal_code { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public string Date { get; set; }
        public int Product_id { get; set; }
        public int Price { get; set; }
    }
}