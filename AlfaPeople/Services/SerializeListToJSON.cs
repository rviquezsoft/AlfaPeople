using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlfaPeople.Models;
using Newtonsoft.Json;

namespace AlfaPeople
{
    public class SerializeListToJSON : ISerializeListToJSON
    {
        private readonly IExceptionsService logger;
        public SerializeListToJSON(IExceptionsService _logger)
        {
            logger = _logger;
        }

        /// <summary>
        /// Serializa una lista de pedidos y devuelve la serialización
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public async Task<string> serialize(List<IPedidoBase> pedidos)
        {
            string payload = "";
            try
            {
                payload = JsonConvert.SerializeObject(pedidos,Formatting.Indented,
                    new JsonSerializerSettings {
                        NullValueHandling=NullValueHandling.Ignore
                    });
            }
            catch (Exception ex)
            {
                await logger.LogToLogger(this.GetType().Name, ex);
            }
            return payload;
        }
    }
}

