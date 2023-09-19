using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(c =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default") ?? "";

    return new ADOContext(connectionString);
});

builder.Services.AddScoped<IRepositorio<Componente>, RepositorioComponenteADO>();
builder.Services.AddScoped<IRepositorio<Ordenador>, RepositorioOrdenadorADO>();
builder.Services.AddScoped<IRepositorio<Pedido>, RepositorioPedidoADO>();
builder.Services.AddScoped<IRepositorio<Factura>, RepositorioFacturaADO>();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
