using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dr.TeslaApiFacade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            string portFromEnv = Environment.GetEnvironmentVariable("PORT") ?? "5000";
            Action<IWebHostBuilder> config = b => { };
            if (Int32.TryParse(portFromEnv, out int port))
            {
                config = b => b.UseUrls($"http://0.0.0.0:{port}");
            }

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    config(webBuilder);
                });
        }
    }
}
