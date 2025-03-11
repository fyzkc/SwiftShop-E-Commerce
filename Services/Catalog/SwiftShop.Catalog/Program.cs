using Microsoft.Extensions.Options;
using SwiftShop.Catalog.Services.CategoryServices;
using SwiftShop.Catalog.Services.ProductDetailServices;
using SwiftShop.Catalog.Services.ProductImageServices;
using SwiftShop.Catalog.Services.ProductServices;
using SwiftShop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());  // Registers only the AutoMapper profiles in the current executing assembly (project). 
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Registers AutoMapper profiles from all loaded assemblies (not ideal for microservices).

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
// This maps the "DatabaseSettings" section from appsettings.json to the DatabaseSettings class properties.
// The Configure<T> method registers these settings in the Dependency Injection container as IOptions<T>.

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
// This registers IDatabaseSettings as a scoped service in the Dependency Injection container. 
// Previously, the settings were registered as IOptions<DatabaseSettings>. Here, we retrieve the settings 
// from the DI container and return them as an IDatabaseSettings instance.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
