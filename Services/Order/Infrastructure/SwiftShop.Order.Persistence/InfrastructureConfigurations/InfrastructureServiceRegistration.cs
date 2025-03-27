using Microsoft.Extensions.DependencyInjection;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Persistence.InfrastructureConfigurations
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
