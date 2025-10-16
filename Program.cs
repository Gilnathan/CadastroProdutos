using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};



app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


app.MapGet("/test", () => "Esse e um EndPoint de teste");


var Produtos = new List<Produto>()
{
    new Produto(){ Id = 1, Nome = "Mouse sem fio", Preco =40.90M, Estoque = 50 },
    new Produto(){ Id = 2, Nome = "Teclado sem fio", Preco =20.90M, Estoque = 20 }
};

app.MapGet("/produtos", () =>
{
    return Produtos;
});


app.MapGet("/produtos/{id}", (int id) =>
{
    var produto = Produtos.FirstOrDefault((x) => x.Id == id);

    if( produto != null)
    {
        return Results.Ok(produto);
    }
    else
    {
        return Results.NotFound($"Foi mal men, não achei o Produto {id}");
    }
});




app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } 
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}