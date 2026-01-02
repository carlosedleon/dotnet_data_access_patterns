namespace Common.Entities;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public decimal Amount { get; set; }

    public List<OrderItemDiscount> Discounts { get; set; } = new();
}