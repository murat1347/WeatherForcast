using WeatherApp.Dto;
using WeatherApp.Entity;

namespace WeatherApp.Services.WeatherService
{
    public interface IWeatherService
    {
        Task<List<CityView>> GetForeacastByDate(DateTime date);
        Task<ReadSumaryDto> ReadAndWriteForecast();
    }
}
