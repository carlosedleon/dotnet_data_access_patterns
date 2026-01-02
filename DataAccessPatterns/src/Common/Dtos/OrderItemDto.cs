namespace Common.Dtos;
public class OrderItemDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public List<OrderItemDiscountDto> Discounts { get; set; } = new();
}