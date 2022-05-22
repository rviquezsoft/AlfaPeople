using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AlfaPeople.Models;

namespace AlfaPeople
{
    public class DeserealizeXMLService : IDeserealizeXMLService
    {
        private readonly IExceptionsService logger;
        public DeserealizeXMLService(IExceptionsService _logger)
        {
            logger = _logger;
        }

        /// <summary>
        /// Recibe el mapeo de tipos del archivo appsettings.json en el cual se
        /// deben definir los tipos y el nombre de la carpeta de esos tipos
        /// para poder hacer un mapeo de lo que se necesita procesar
        /// </summary>
        /// <param name="directories"></param>
        /// <returns></returns>
		public async Task<List<IPedidoBase>> deserealize(List<Folders> folders)
        {
            List<IPedidoBase> pedidos = new List<IPedidoBase>();
            try
            {
                //se agregan  a la lista los pedidos
                //pero utilizando la interfaz para
                //poder agregarlos a todos a la misma lista
                foreach (var item in folders)
                {
                    IPedidoBase temp = null;
                    if (item.tipo == nameof(PedidoCompra))
                    {
                        var files = Directory.GetFiles(item.carpeta, "*.xml");
                        foreach (var f in files)
                        {
                            XmlSerializer serializer =
                                new XmlSerializer(typeof(PedidoCompra));
                            using (FileStream fs = File.Open(f, FileMode.Open))
                            {
                                temp = (PedidoCompra)serializer.Deserialize(fs);
                            }
                            pedidos.Add(temp);
                        }
                    }
                    if (item.tipo == nameof(PedidoVenta))
                    {
                        var files = Directory.GetFiles(item.carpeta, "*.xml");
                        foreach (var f in files)
                        {
                            XmlSerializer serializer =
                                new XmlSerializer(typeof(PedidoVenta));
                            using (FileStream fs = File.Open(f, FileMode.Open))
                            {
                                temp = (PedidoVenta)serializer.Deserialize(fs);
                            }
                            pedidos.Add(temp);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                await logger.LogToLogger(this.GetType().Name, ex);
            }

            return pedidos;
        }
    }
}

