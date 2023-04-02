using System.Xml.Serialization;

namespace WeatherApp.Dto.XmlSerialization
{
    public class CityDto
    {
        [XmlElement("Durum")]
        public string? Status { get; set; }

        [XmlElement("Mak")]
        public int MaximumDegree { get; set; }

        [XmlElement("ili")]
        public string? CityName { get; set; }
    }
}
