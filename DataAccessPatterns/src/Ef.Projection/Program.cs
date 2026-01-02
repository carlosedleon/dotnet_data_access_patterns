using Common.Data;
using Common.Dtos;
using System.Diagnostics;

using var ctx = new AppDbContext();

var sw = Stopwatch.StartNew();

var orders = ctx.Orders
    .Select(o => new OrderDto
    {
        Id = o.Id,
        CreatedAt = o.CreatedAt,
        Items = o.Items.Select(i => new OrderItemDto
        {
            Id = i.Id,
            Amount = i.Amount,
            Discounts = i.Discounts.Select(d => new OrderItemDiscountDto
            {
                Id = d.Id,
                Amount = d.Amount
            }).ToList()
        }).ToList()
    })
    .ToList();

sw.Stop();

Console.WriteLine($"Orders loaded: {orders.Count}");
Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds} ms");
