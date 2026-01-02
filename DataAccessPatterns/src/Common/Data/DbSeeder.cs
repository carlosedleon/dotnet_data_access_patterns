using Common.Entities;

namespace Common.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext ctx)
    {
        if (ctx.Orders.Any())
            return;

        var orders = new List<Order>();

        for (int o = 0; o < 10; o++)
        {
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow
            };

            for (int i = 0; i < 20; i++)
            {
                var item = new OrderItem();

                for (int d = 0; d < 5; d++)
                {
                    item.Discounts.Add(new OrderItemDiscount
                    {
                        Amount = d + 1
                    });
                }

                order.Items.Add(item);
            }

            orders.Add(order);
        }

        ctx.Orders.AddRange(orders);
        ctx.SaveChanges();
    }
}
