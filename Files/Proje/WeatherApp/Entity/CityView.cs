using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Entity
{
    [Table("cityview")]
    public class CityView : BaseEntity
    {
        [Column("sehir_adi")]
        public string Name { get; set; }

        [Column("durum")]
        public string Status { get; set; }

        [Column("tarih")]
        public DateTime Date { get; set; }

        [Column("mak")]
        public int MaximumDegree { get; set; }
    }
}
