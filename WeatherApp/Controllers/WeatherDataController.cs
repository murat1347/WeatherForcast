using Microsoft.AspNetCore.Mvc;
using WeatherApp.Context;

using WeatherApp.Services.WeatherService;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherDataController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherDataController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetWeatherData(DateTime date)
        {
            return this.Ok(await weatherService.GetForeacastByDate(date));
        }

        [Route("/read-forecast-data")]
        [HttpGet]
        public async Task<ActionResult> ReadForecastData()
        {
            return this.Ok(await weatherService.ReadAndWriteForecast());
        }
    }
}
