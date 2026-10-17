using DailyCore.Application.Empresas.Interfaces;
using DailyCore.Application.Empresas.Service;
using DailyCore.Infrastructure.Persistence.Repositories;
using DailyCore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<EmpresaService>();

var connectionString = builder.Configuration.GetConnectionString("DailyCore")
    ?? throw new InvalidOperationException("Falta configurar ConnectionStrings:DailyCore.");

builder.Services.AddDbContext<DailyCoreDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "DailyCore API v1"));
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
