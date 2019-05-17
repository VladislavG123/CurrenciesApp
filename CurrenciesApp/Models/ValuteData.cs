using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrenciesApp.Models
{
   [XmlRoot(ElementName = "rss")]
    public class ValuteData
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
   }
}


