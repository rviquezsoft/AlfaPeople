using System.Xml.Serialization;

namespace AlfaPeople.Models
{
    [XmlRoot(ElementName = "LineasPedidoVenta")]
	public class LineasPedidoVenta:LineaBase
	{

		[XmlElement(ElementName = "CantidadVenta")]
		public string CantidadVenta { get; set; }
		[XmlElement(ElementName = "UnidadVenta")]
		public string UnidadVenta { get; set; }
	}
}

