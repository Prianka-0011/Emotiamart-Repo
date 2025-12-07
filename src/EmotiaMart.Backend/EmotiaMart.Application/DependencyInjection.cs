using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using EmotiaMart.Application.Users.Queries;
using EmotiaMart.Application.Common;
using EmotiaMart.Application.Common.Interfaces;
using AutoMapper;

namespace EmotiaMart.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IApplicationSettings, ApplicationSettings>();

            return services;
        }
    }
}
