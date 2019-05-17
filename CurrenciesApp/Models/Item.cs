using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrenciesApp.Models
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }
        [XmlElement(ElementName = "description")]
        public double? Description { get; set; }
        [XmlElement(ElementName = "quant")]
        public string Quant { get; set; }
        [XmlElement(ElementName = "index")]
        public string Index { get; set; }
        [XmlElement(ElementName = "change")]
        public double? Change { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
    }
}
