using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Components;

public class Delay : ComponentBase, IDisposable
{
  [Parameter]
  public double TimeInSeconds { get; set; }

  [Parameter]
  public EventCallback Tick { get; set; } = default!;

  private Timer timer = default!;

  protected override void OnInitialized()
  {
    timer = new(
      callback: async (_) => await InvokeAsync(async () => await Tick.InvokeAsync()),
      state: null,
      dueTime: TimeSpan.FromSeconds(TimeInSeconds),
      period: TimeSpan.FromSeconds(TimeInSeconds));
  }

  public void Dispose() => timer.Dispose();
}
