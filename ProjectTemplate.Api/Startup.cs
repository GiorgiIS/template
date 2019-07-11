using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using ProjectTemplate.Application;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Repository.EF;
using ProjectTemplate.Repository.Implementations;
using ProjectTemplate.Repository.Interfaces;
using AutoMapper;
using ProjectTemplate.Common.Api;
using ProjectTemplate.Services.Interfaces;
using ProjectTemplate.Services;

namespace ProjectTemplate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration["ConnectionStrings:Default"];
            services.AddDbContext<CustomDbContext>(options => options.UseSqlServer(connectionString));

            var assemblies = typeof(AutomapperProfile).Assembly;
            services.AddAutoMapper(assemblies);

            services.RegisterServices();

            services.AddOpenApiDocument(); // add OpenAPI v3 document
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseOpenApi(); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(); // serve Swagger UI
            app.UseReDoc(); // serve ReDoc UI

            app.UseMvc();
        }
    }
}
