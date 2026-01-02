using Common.Data;

using var ctx = new AppDbContext();
ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();

DbSeeder.Seed(ctx);

Console.WriteLine("Database seeded");