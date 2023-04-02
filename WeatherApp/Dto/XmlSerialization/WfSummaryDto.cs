using System.Xml.Serialization;

namespace WeatherApp.Dto.XmlSerialization
{
    public class WfSummaryDto
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement("Tarih")]
        public string CustomeDateFormat
        {
            get { return Date.ToString("dd.MM.yyyy"); }
            set { Date = DateTime.Parse(value); }
        }
    }
}
