using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopsRUsDiscounts.Api.Helpers;
using ShopsRUsDiscounts.Application.Handlers.CommandHendlers;
using ShopsRUsDiscounts.Domain.Events;
using ShopsRUsDiscounts.Domain.Interfaces;
using ShopsRUsDiscounts.Infrastructure.Context;
using ShopsRUsDiscounts.Infrastructure.Cunsomers;
using ShopsRUsDiscounts.Infrastructure.MessageBroker;
using ShopsRUsDiscounts.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DbConnection");


builder.Services.AddDbContext<ShopsRUsDiscountsDBContext>(options => 
options.UseSqlServer(connectionString));

builder.Services.AddMediatR(typeof(CreateOrderCommandHandler));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<SyncCreateInvoiceCunsomer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(builder.Configuration.GetConnectionString("RabbitMQCon")), host => { });

        cfg.ReceiveEndpoint(EventPublish.SyncInvoiceQueue, e =>
        {
            e.ConfigureConsumer<SyncCreateInvoiceCunsomer>(context);
        });
    });
});


builder.Services.AddScoped<IEventPublish, EventPublish>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


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


