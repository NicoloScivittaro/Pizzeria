using Pizzeria.Models;


    public class Order
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}

