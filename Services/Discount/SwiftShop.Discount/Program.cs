using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SwiftShop.Discount.Context;
using SwiftShop.Discount.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "DiscountResource";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddAuthorization(options =>
{
    //its necessary to have CatalogReadPermission or CatalogFullPermission to make a GET request.
    options.AddPolicy("DiscountReadOrFullPolicy", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                (c.Type == "scope" && c.Value == "DiscountReadPermission") ||
                (c.Type == "scope" && c.Value == "DiscountFullPermission")
            )
        )
    );

    //its necessary to have CatalogFullPermission to make a POST request. 
    options.AddPolicy("DiscountFullPolicy", policy =>
        policy.RequireClaim("scope", "DiscountFullPermission")
    );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddTransient<DapperContext>();
builder.Services.AddTransient<IDiscountService, DiscountService>();

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
