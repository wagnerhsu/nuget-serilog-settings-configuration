using Volo.Abp.DependencyInjection;

namespace MiniApiDemo;

public class HelloService : ITransientDependency
{
    private readonly ILogger<HelloService> _logger;

    public HelloService(ILogger<HelloService> logger)
    {
        _logger = logger;
    }
    public string SayHi()
    {
        _logger.LogInformation("SayHi");
        return "Hi from service";
    }
}
