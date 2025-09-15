using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class LoggerExampleBase : ComponentBase
{
    [Inject]
    private ILogger<LoggerExampleBase> _logger { get; set; } = default!;

    protected void LogDebug() => _logger.LogDebug("Hmmmm...");
    protected void LogInformation() => _logger.LogInformation("Hi there!");
    protected void LogWarning() => _logger.LogWarning("Some warning");
    protected void LogError() => _logger.LogError("Some error");
    protected void LogCritical() => _logger.LogCritical("Aaahhhhh!");
    protected void LogConsole() => Console.WriteLine("This works too!");

}