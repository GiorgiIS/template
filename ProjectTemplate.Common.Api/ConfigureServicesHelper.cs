﻿using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Repository.Implementations;
using ProjectTemplate.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Common.Api
{
    public static class ConfigureServicesHelper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITestRepository, TestRepository>();
            return services;
        }
    }
}