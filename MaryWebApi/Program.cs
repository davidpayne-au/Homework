// Importing the MaryLib namespace
using MaryLib;

// Creating a web application builder
var builder = WebApplication.CreateBuilder(args);

// Adding a scoped service to the dependency injection container
builder.Services.AddScoped<IService, Service>();

// Adding controllers to the service collection
builder.Services.AddControllers();

// Adding API explorer services to the service collection
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Building the web application
var app = builder.Build();

// Configuring the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enabling Swagger and Swagger UI in the development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enabling HTTPS redirection
app.UseHttpsRedirection();

// Array of weather summaries
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Mapping a GET request to the "/weatherforecast" endpoint
app.MapGet("/weatherforecast", () =>
{
    // Generating a weather forecast using LINQ
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
// Assigning a name to the endpoint and enabling OpenAPI documentation
.WithName("GetWeatherForecast")
.WithOpenApi();

// Mapping another GET request to the "/api/calculator/add/{a}/{b}" endpoint
app.MapGet("/api/calculator/add/{a}/{b}", (int a, int b) => $"{a + b}");

// Running the web application
app.Run();

// Defining a record type for WeatherForecast
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    // Calculating temperature in Fahrenheit
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
