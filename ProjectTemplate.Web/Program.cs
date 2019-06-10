using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace ProjectTemplate.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.Title = "WEB";
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .WriteTo.ColoredConsole()
               .WriteTo.File(
               new Serilog.Formatting.Json.JsonFormatter(),
               @"logs/log-.log",
               fileSizeLimitBytes: 1_000_000,
               rollOnFileSizeLimit: true,
               rollingInterval: RollingInterval.Day,
               shared: true,
               flushToDiskInterval: TimeSpan.FromSeconds(1))
               .CreateLogger();
            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
