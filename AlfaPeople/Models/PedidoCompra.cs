using System;
using System.Xml.Serialization;

namespace AlfaPeople.Models
{

    [XmlRoot(ElementName = "PedidoCompra")]
	public class PedidoCompra:PedidoBase,IPedidoBase
	{
		[XmlElement(ElementName = "CodigoCompra")]
		public string CodigoCompra { get; set; }
		[XmlElement(ElementName = "NombreProveedor", IsNullable = true)]
		public string NombreProveedor { get; set; }
		[XmlElement(ElementName = "FechaCompra", IsNullable = true)]
		public string FechaCompra { get; set; }
		[XmlElement(ElementName = "Lineas")]
		public LineasCompra Lineas { get; set; }
		
	}
}

