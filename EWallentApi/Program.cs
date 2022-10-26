using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Net;

namespace EWallentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Electron Wallet API";
            Console.WriteLine($@"Process Id: {Process.GetCurrentProcess().Id}");

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .WriteTo.Console()
               .WriteTo.File("log.txt", LogEventLevel.Debug, rollingInterval: RollingInterval.Day)
               .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 2012, listenOptions =>
                    {
                        //certificate settings for https
                    });
                })
                .UseStartup<Startup>();
    }
}

