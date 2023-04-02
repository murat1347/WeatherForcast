using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Entity
{
    [Table("sehir_havadurumu")]
    public class CityWeather:BaseEntity
    {

        public City City { get; set; }

        [ForeignKey("City")]
        [Column("sehir_id")]
        public int CityId { get; set; }

        [Column("tarih")]
        public DateTime Date { get; set; }

        [Column("durum")]
        public string Status { get; set; }

        [Column("mak")]
        public int MaximumDegree { get; set; }

        [Column("kayit_tarihi")]
        public DateTime CreatedDate{ get; set; }
    }
}
