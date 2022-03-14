using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;
#endregion

namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            // Within this method, we will register all the services that will be used
            // by the system (context setup)
            // and will be provided by the system.

            // Setup the context service
            services.AddDbContext<WestWindContext>(options);

            // Register the service classes

            // Add any business logic layer to the service collection so our
            // webapp has access to the methods (services) within the BLL class.

            // The argument for the AddTransient is called a factory
            // Basically what you are add is a localize method.
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                // Get the dbcontext class that has been registered.
                var context = serviceProvider.GetService<WestWindContext>();

                // Create an instance of the service class (BuildVersionServices) supplying
                // the context reference to the service class.
                // return the service class instance
                return new BuildVersionServices(context);
            });

            services.AddTransient<RegionServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();
                return new RegionServices(context);
            });
        }
    }
}
