using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RedisServer;

public class RedisServer (IRedisCommandParser commandParser, IOptions<ConnectionSettings> options, ILogger<RedisServer> logger) : IServer
{
    public void Run()
    {
        logger.LogWarning("Logging started...");
        logger.LogInformation("Port is {Port}", options.Value.Port);
        commandParser.ParseCommand();
    }
}