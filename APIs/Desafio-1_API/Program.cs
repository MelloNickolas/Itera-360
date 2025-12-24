using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registrar DbContext (mesmo com OnConfiguring, isso ajuda o DI)
builder.Services.AddDbContext<Contexto>();

// Registrar o repositório
builder.Services.AddScoped<IJogoRepository, JogoRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
