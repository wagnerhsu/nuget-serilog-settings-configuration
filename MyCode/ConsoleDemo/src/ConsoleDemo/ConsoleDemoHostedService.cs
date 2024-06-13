using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Volo.Abp;

namespace ConsoleDemo;

public class ConsoleDemoHostedService : IHostedService
{
    private readonly HelloWorldService _helloWorldService;
    private readonly ILogger<ConsoleDemoHostedService> _logger;

    public ConsoleDemoHostedService(HelloWorldService helloWorldService, ILogger<ConsoleDemoHostedService> logger)
    {
        _helloWorldService = helloWorldService;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _helloWorldService.SayHelloAsync();
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
            _logger.LogInformation("Info:"+DateTime.Now.ToString("O"));
            _logger.LogDebug("Debug:"+DateTime.Now.ToString("O"));
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
