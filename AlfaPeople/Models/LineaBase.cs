using System;
using System.Xml.Serialization;

namespace AlfaPeople.Models
{
	public class LineaBase
	{
		[XmlElement(ElementName = "CodigoProducto")]
		public string CodigoProducto { get; set; }
		[XmlElement(ElementName = "Nombre", IsNullable = true)]
		public string Nombre { get; set; }
		[XmlElement(ElementName = "Almacen", IsNullable = true)]
		public string Almacen { get; set; }
		[XmlElement(ElementName = "Estilo", IsNullable = true)]
		public string Estilo { get; set; }
		[XmlElement(ElementName = "Color", IsNullable = true)]
		public string Color { get; set; }
		[XmlElement(ElementName = "Talla", IsNullable = true)]
		public string Talla { get; set; }
	}
}

