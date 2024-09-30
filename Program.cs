using api.DB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration["MongoSettings:ConnectionString"];
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<ApiDBContext>(sp =>
{
    var mongoClient = sp.GetRequiredService<IMongoClient>();
    var databaseName = builder.Configuration["MongoSettings:DatabaseName"];
    return new ApiDBContext(mongoClient, databaseName);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000", "https://localhost:3000", "http://192.168.1.102:3000", "https://192.168.1.102:3000", "https://192.168.1.100:3000", "http://192.168.1.100:3000") // Porta do React
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
