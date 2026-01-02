using Common.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

Console.WriteLine("EF Core - SingleQuery Include");

using var ctx = new AppDbContext();

var sw = Stopwatch.StartNew();

var orders = ctx.Orders
    .Include(o => o.Items)
        .ThenInclude(i => i.Discounts)
    .ToList();

sw.Stop();

Console.WriteLine($"Orders loaded: {orders.Count}");
Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds} ms");
