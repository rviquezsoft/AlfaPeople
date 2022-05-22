using System.Collections.Generic;
using System.Xml.Serialization;

namespace AlfaPeople.Models
{
    [XmlRoot(ElementName = "Lineas")]
	public class LineasCompra
	{
		[XmlElement(ElementName = "LineaPedidoCompra")]
		public List<LineaPedidoCompra> LineaPedidoCompra { get; set; }
	}
}

