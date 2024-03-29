﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Utils;
using ProductApp.Persistance.Context;
using ProductApp.Persistance.Repositories.Concrete;

namespace ProductApp.Persistance
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
