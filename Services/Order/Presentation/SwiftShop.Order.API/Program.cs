using Microsoft.EntityFrameworkCore;
using SwiftShop.Order.Application.Configurations;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Persistence.Context;
using SwiftShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices(builder.Configuration); //we add the AddApplicationServices method from the ServiceRegistration class. 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//this code sends the options parameter to the OrderContext class's constructor method. 
//OrderContext is adding into the DI Container. 
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderDbConnection")));

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
