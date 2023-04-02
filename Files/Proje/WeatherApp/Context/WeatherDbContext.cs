using Microsoft.EntityFrameworkCore;
using WeatherApp.Entity;

namespace WeatherApp.Context
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

       public DbSet<City> City {get; set;}

       public DbSet<CityWeather> CityWeathers {get; set;}

       public DbSet<CityView> CityViews { get; set; }
    }
}
