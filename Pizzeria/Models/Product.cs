namespace Pizzeria.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public int DeliveryTime { get; set; }
        public string Ingredients { get; set; }
    }
}
