using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SwiftShop.Order.Application.Configurations;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Persistence.Context;
using SwiftShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "OrderResource";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddAuthorization(options =>
{
    //its necessary to have CatalogReadPermission or CatalogFullPermission to make a GET request.
    options.AddPolicy("OrderReadOrFullPolicy", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                (c.Type == "scope" && c.Value == "OrderReadPermission") ||
                (c.Type == "scope" && c.Value == "OrderFullPermission")
            )
        )
    );

    //its necessary to have CatalogFullPermission to make a POST request. 
    options.AddPolicy("OrderFullPolicy", policy =>
        policy.RequireClaim("scope", "OrderFullPermission")
    );
});


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
