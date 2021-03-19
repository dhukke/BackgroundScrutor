using BackgroundScrutor.Cache;
using BackgroundScrutor.Repository;
using BackgroundScrutor.Repository.Cached;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using StackExchange.Redis;

namespace BackgroundScrutor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var a =  Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    configuration
                        .Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .WriteTo.Console()
                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .ReadFrom.Configuration(context.Configuration);

                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.AddSingleton<IConnectionMultiplexer>(x =>
                        ConnectionMultiplexer.Connect(hostContext.Configuration.GetValue<string>("RedisConnection"))
                    );
                    services.AddSingleton<ICacheService, RedisCacheService>();

                    services.AddSingleton<IThingRepository, ThingRepository>();
                    services.Decorate<IThingRepository, CachedThingRepository>();
                });


            return a;
        }
    }
}
