using BlazorShop.API.Context;
using BlazorShop.API.Interfaces;
using BlazorShop.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opitons => {
    opitons.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// A cada requisição uma Instancia é criada, usando AddScoped
// Se quisesse sempre a mesms intancia, usariamos AddSngleton
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
