
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.Business.Concrete;
using SwiftShop.Shipping.DataAccess.Abstract;
using SwiftShop.Shipping.DataAccess.Concrete;
using SwiftShop.Shipping.DataAccess.Repositories;
using SwiftShop.Shipping.Dto.Mapping;
using System.Reflection;

namespace SwiftShop.Shipping.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ShippingResource";
                opt.RequireHttpsMetadata = false;
            });

            builder.Services.AddAuthorization(options =>
            {
                //its necessary to have CatalogReadPermission or CatalogFullPermission to make a GET request.
                options.AddPolicy("ShippingReadOrFullPolicy", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(c =>
                            (c.Type == "scope" && c.Value == "ShippingReadPermission") ||
                            (c.Type == "scope" && c.Value == "ShippingFullPermission")
                        )
                    )
                );

                //its necessary to have CatalogFullPermission to make a POST request. 
                options.AddPolicy("ShippingFullPolicy", policy =>
                    policy.RequireClaim("scope", "ShippingFullPermission")
                );
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ShippingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDbConnection")));

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Profiles)));

            //repositories
            builder.Services.AddScoped<ICarrierRepository, CarrierRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();

            //services
            builder.Services.AddScoped<ICarrierService, CarrierService>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IShipmentService, ShipmentService>();

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
        }
    }
}
