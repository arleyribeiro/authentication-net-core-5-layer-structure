using AutoMapper;
using Core.Interfaces.Security;
using Core.Interfaces.Services;
using Core.Security;
using Core.Services;
using Core.Validators;
using Core.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using FluentValidation.AspNetCore;

namespace Core.IoC
{
    public static class CoreIoC
    {
        public static void CoreServiceIoc(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainProfile>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHahser>();
            services.AddMvc().AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
        }

    }
}
