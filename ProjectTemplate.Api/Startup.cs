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
using NSwag.SwaggerGeneration.Processors.Security;
using ProjectTemplate.Application;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Repository.EF;
using ProjectTemplate.Repository.Implementations;
using ProjectTemplate.Repository.Interfaces;

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

            services.AddScoped<ITestRepository, TestRepository>();

            services.AddScoped<ITestService, TestService>();

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

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.SwaggerUiRoute = Configuration["SwaggerSpecs:Route"];
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                settings.GeneratorSettings.DefaultEnumHandling = EnumHandling.String;

                settings.PostProcess = document =>
                {
                    document.Info.Version = Configuration["SwaggerSpecs:Version"];
                    document.Info.Title = Configuration["SwaggerSpecs:Title"];
                    document.Info.Description = Configuration["SwaggerSpecs:Description"];
                    document.Info.TermsOfService = Configuration["SwaggerSpecs:TermsOfService"];
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = Configuration["SwaggerSpecs:Contact"],
                        Email = Configuration["SwaggerSpecs:Email"]
                    };
                };
            });

            app.UseMvc();
        }
    }
}
