using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RedisServer;

public abstract class Program
{
    private static void Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        var services = new ServiceCollection()
            .AddLogging(options =>
            {
                options.ClearProviders();
                options.AddConsole();
            })
            .AddOptions()
            .AddSingleton<IServer, RedisServer>()
            .AddSingleton<IRedisCommandParser, RedisCommandParser>();

        services.Configure<ConnectionSettings>(config.GetSection("Connection"));

        var provider = services.BuildServiceProvider();
        var redisServer = provider.GetRequiredService<IServer>();
        
        redisServer.Run();
    }
}