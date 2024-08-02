namespace InFornoWebApp.Models
{
    public class ProductIngredient
    {
        public int  ? ProductId { get; set; }
        public Product ? Product { get; set; }

        public int ? IngredientId { get; set; }
        public Products ? Ingredient { get; set; }
    }
}
