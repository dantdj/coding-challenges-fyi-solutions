using Microsoft.Extensions.Logging;

namespace RedisServer;

public class RedisCommandParser(ILogger<RedisCommandParser> logger): IRedisCommandParser
{
    public void ParseCommand()
    {
        logger.LogInformation("Parsing...");
    }
}