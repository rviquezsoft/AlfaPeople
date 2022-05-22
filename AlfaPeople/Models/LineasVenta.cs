using System.Collections.Generic;
using System.Xml.Serialization;

namespace AlfaPeople.Models
{
    [XmlRoot(ElementName = "Lineas")]
	public class LineasVenta
	{
		[XmlElement(ElementName = "LineasPedidoVenta")]
		public List<LineasPedidoVenta> LineasPedidoVenta { get; set; }
	}
}

