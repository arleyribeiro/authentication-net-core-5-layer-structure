using Core.Interfaces.Security;
using Core.Interfaces.Services;
using Core.Security;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.IoC
{
    public static class CoreIoC
    {
        public static void CoreServiceIoc(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHahser>();
        }

    }
}
