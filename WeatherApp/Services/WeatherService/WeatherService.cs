using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Xml.Serialization;
using WeatherApp.Context;
using WeatherApp.Dto;
using WeatherApp.Dto.XmlSerialization;
using WeatherApp.Entity;

namespace WeatherApp.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherDbContext context;

        public WeatherService(WeatherDbContext context)
        {
            this.context = context;
        }

        private async Task<string> GetWeatherDataFromService()
        {
            var url = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadAsStringAsync(); 
        }

        private async Task<WeatherForecastDto> GetWeatherForecast()
        {
            var xmlResponse = await GetWeatherDataFromService();

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "SOA";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(WeatherForecastDto), xRoot);
            using (TextReader reader = new StringReader(xmlResponse))
            {
                var result = serializer.Deserialize(reader);
                if (result != null)
                {
                    WeatherForecastDto weatherDto = (WeatherForecastDto)result;
                    return weatherDto;
                }
            }

            return null;
        }

        private async Task<bool> SaveForecast(DateTime forecastDate, CityDto city)
        {
            object[] NpgsqlParameters = new NpgsqlParameter[]
                      {
                new NpgsqlParameter("@city", city.CityName),
                    new NpgsqlParameter("@tarih", forecastDate),
                    new NpgsqlParameter("@durum", city.Status),
                    new NpgsqlParameter("@mak", city.MaximumDegree),
                    new NpgsqlParameter("@kayit_tarihi", DateTime.UtcNow)
                      };

            return await context.Database.ExecuteSqlRawAsync("call set_weather_data(@city, @tarih, @durum, @mak, @kayit_tarihi)", NpgsqlParameters) == 1;
        }

        private async Task<int> WriteForecastsToDb(WeatherForecastDto dto)
        {
            int count = 0;

            if (dto.Cities == null) return 0;

            foreach(var city in dto.Cities)
            {
                if(await context.City.AnyAsync(y => y.Name == city.CityName))
                {
                    await SaveForecast(dto.WfSummaryDto.Date, city);
                    count++;
                }
            }

            return count;
         }

        public async Task<ReadSumaryDto> ReadAndWriteForecast()
        {
            var result = await GetWeatherForecast();
            var writeResult = await WriteForecastsToDb(result);
            return new ReadSumaryDto
            {
                ReadCount = writeResult
            };
        }

        public async Task<List<CityView>> GetForeacastByDate(DateTime date)
        {
            return await context.CityViews.Where(x=>x.Date.Date == date.Date).ToListAsync();
        }
    }
}
