using System.Xml.Serialization;

namespace WeatherApp.Dto.XmlSerialization
{
    public class WeatherForecastDto
    {
        [XmlElement("Kemo")]
        public WfSummaryDto? WfSummaryDto { get; set; }

        [XmlElement("sehirler")]
        public List<CityDto>? Cities { get; set; }
    }
}
