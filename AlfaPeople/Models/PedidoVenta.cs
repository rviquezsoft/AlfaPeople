using System;
using System.Xml.Serialization;

namespace AlfaPeople.Models
{

    [XmlRoot(ElementName = "PedidoVenta")]
	public class PedidoVenta: PedidoBase, IPedidoBase
	{
		[XmlElement(ElementName = "CodigoVenta")]
		public string CodigoVenta { get; set; }
		[XmlElement(ElementName = "NombreCliente")]
		public string NombreCliente { get; set; }
		[XmlElement(ElementName = "FechaVenta")]
		public string FechaVenta { get; set; }
		[XmlElement(ElementName = "Lineas")]
		public LineasVenta Lineas { get; set; }
	
	}
}

