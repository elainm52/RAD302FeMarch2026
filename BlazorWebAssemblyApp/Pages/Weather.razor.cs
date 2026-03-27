using DataServices;
using Microsoft.AspNetCore.Components;
using WebAPI;

namespace BlazorWebAssemblyApp.Pages
{
    public partial class Weather
    {
        private List<WeatherForecast>? forecasts;

        [Inject]
        public IHttpClientService? httpClientService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (httpClientService != null)
                forecasts = await httpClientService.getCollection<WeatherForecast>("WeatherForecast");
            await base.OnInitializedAsync();
        }
    }
}
