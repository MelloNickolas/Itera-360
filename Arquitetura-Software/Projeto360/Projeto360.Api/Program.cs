using Microsoft.EntityFrameworkCore;
using Projeto360.Application;
using Projeto360.Repositories;
using Projeto360.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ITarefaAplicacao, TarefaAplicacao>();

//Adicionando as interfaces de pango de dados 
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IJsonPlaceHolderService, JsonPlaceHolderService>();


// adicionar o servido do banco de dados 
builder.Services.AddDbContext<Projeto360Context>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");   // 👈 aqui

app.UseAuthorization();

app.MapControllers();

app.Run();
