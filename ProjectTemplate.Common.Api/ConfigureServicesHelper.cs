using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Repository.Implementations;
using ProjectTemplate.Repository.Interfaces;

namespace ProjectTemplate.Common.Api
{
    public static class ConfigureServicesHelper
    {
        public static IServiceCollection RegisterServicesAndRepositorys(this IServiceCollection services)
        {
			return services;
        }
    }
}
