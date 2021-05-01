using Infrastructure.DBConfiguration;
using Infrastructure.Repositories;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.DBConfiguration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.IoC
{
    public static class InfrastructureIoc
    {
        public static void InfrastructureServiceIoc(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseProvider, DatabaseProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
