using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
