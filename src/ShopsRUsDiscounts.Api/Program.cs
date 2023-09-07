using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopsRUsDiscounts.Api.Helpers;
using ShopsRUsDiscounts.Application.Handlers.CommandHendlers;
using ShopsRUsDiscounts.Domain.Interfaces;
using ShopsRUsDiscounts.Infrastructure.Context;
using ShopsRUsDiscounts.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DbConnection");


builder.Services.AddDbContext<ShopsRUsDiscountsDBContext>(options => 
options.UseSqlServer(connectionString,
builder => builder.MigrationsAssembly("ShopsRUsDiscounts.Infrastructure")));

builder.Services.AddMediatR(typeof(CreateOrderCommandHandler));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();


var app = builder.Build();

app.MigrateDatabase();


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


