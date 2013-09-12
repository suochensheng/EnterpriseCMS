using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Cargo
{
    [XmlRoot("CityID")]
    public class ChinaCityXMLModel
    {
        public Province[] Province { get; set; }

    }

    [XmlRoot("CityID")]
    public class Province 
    {
        public Province()
        {
           // City = new List<City>();
        }

        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlArrayItem(Type = typeof(City), ElementName = "City")]
        public List<City> City { get; set; }
    }

    [XmlRoot("CityID")]
    public class City
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
    }
}