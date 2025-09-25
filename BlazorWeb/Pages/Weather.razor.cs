using DataObjects;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorWeb.Pages;

public class WeatherBase : ComponentBase
{
    [Inject(Key = "BlazorWeb")]
    protected HttpClient httpClient { get; set; } = default!;

    public WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}