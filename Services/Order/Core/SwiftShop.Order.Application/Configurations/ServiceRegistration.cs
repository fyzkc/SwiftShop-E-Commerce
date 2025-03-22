using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Configurations
{
    public static class ServiceRegistration // this class is created for the services that will be using in the future. 
    //we can do it in Program.cs too, but in the future if we have more than one service, this class makes it more clear to use.
    //otherwise we should add all the services one by one to the Program.cs. But with this class, we can add our services into here and only add the 
    //AddApplicationServices method into the Program.cs.
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
