var builder = WebApplication.CreateBuilder(args);

// 1. Obsługa CORS dla Reacta
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// 2. Definicja endpointu /weatherforecast zwracającego dane JSON
app.MapGet("/weatherforecast", () =>
{
    var produkty = new[]
    {
        new { Id = 1, Name = "Jabłka", Price = 3.50 },
        new { Id = 2, Name = "Banan", Price = 4.99 },
        new { Id = 3, Name = "Marchew", Price = 2.20 }
    };
    return Results.Ok(produkty);
});

app.Run();