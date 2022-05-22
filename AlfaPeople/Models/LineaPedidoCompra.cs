using System.Xml.Serialization;

namespace AlfaPeople.Models
{
    [XmlRoot(ElementName = "LineaPedidoCompra")]
	public class LineaPedidoCompra:LineaBase
	{
		
		[XmlElement(ElementName = "CantidadCompra", IsNullable = true)]
		public string CantidadCompra { get; set; }
		[XmlElement(ElementName = "UnidadCompra", IsNullable = true)]
		public string UnidadCompra { get; set; }
		
	}
}

