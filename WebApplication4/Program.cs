var builder = WebApplication.CreateBuilder(args);

// додаємо у додаток сервіси Razor Pages

builder.Services.AddRazorPages();

var app = builder.Build();

// додаємо підтримку маршрутизації для Razor Pages

app.MapRazorPages();

app.Run();