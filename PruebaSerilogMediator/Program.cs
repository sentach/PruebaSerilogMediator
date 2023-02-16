using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System.Reflection;

namespace PruebaSerilogMediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CretateLog();
            BuildHost(args).Run();
        }

        
        private static void CretateLog() =>
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        private static IHost BuildHost(string[] args)
        {
            return new HostBuilder()
            .ConfigureServices(services => {
                services.AddSingleton<IHostedService, PruebaService>();
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            })
            .UseSerilog()
            .Build();
        }
    }
}