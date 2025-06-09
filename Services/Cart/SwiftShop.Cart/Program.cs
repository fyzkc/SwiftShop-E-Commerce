
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SwiftShop.Cart.Services;
using SwiftShop.Cart.Settings;
using SwiftShop.Cart.SharedIdentity;
using System.IdentityModel.Tokens.Jwt;

namespace SwiftShop.Cart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub"); //for removing the mapping of sub value.

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "CartResource";
                opt.RequireHttpsMetadata = false;
            });

            builder.Services.AddAuthorization(options =>
            {
                //its necessary to have CatalogReadPermission or CatalogFullPermission to make a GET request.
                options.AddPolicy("CartReadOrFullPolicy", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(c =>
                            (c.Type == "scope" && c.Value == "CartReadPermission") ||
                            (c.Type == "scope" && c.Value == "CartFullPermission")
                        )
                    )
                );

                //its necessary to have CatalogFullPermission to make a POST request. 
                options.AddPolicy("CartFullPolicy", policy =>
                    policy.RequireClaim("scope", "CartFullPermission")
                );
            });

            // Add services to the container.

            builder.Services.AddSingleton<RedisService>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var redisSettings = config.GetSection("RedisSettings").Get<RedisSettings>();

                var redisService = new RedisService(redisSettings.Host, redisSettings.Port);
                redisService.Connect();
                return redisService;
            });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

            builder.Services.AddScoped<ICartService, CartService>();

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

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
