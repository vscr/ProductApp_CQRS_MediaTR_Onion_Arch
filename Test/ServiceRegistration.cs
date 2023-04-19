using Microsoft.Extensions.DependencyInjection;
using ProductApp.Persistance.Context;

namespace Test
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionManager.GetConnectionString()));
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
