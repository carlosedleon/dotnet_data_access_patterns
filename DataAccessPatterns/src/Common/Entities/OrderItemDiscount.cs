namespace Common.Entities;

public class OrderItemDiscount
{
    public int Id { get; set; }

    public int OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; } = null!;

    public decimal Amount { get; set; }
}