using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application;
using ProjectTemplate.Repository.Implementations;
using ProjectTemplate.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
