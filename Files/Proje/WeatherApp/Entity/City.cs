using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Entity
{
    [Table("sehir")]
    public class City : BaseEntity
    {
        [Column("sehir_adi")]
        public string Name { get; set; }

        [Column("plaka_no")]
        public string PlateNumber { get; set; }
    }
}
