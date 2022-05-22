using System;
using System.Xml.Serialization;

namespace AlfaPeople.Models
{
    public class PedidoBase : IPedidoBase
    {
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }
}

