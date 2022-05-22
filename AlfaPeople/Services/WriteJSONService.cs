using System;
using System.IO;
using System.Threading.Tasks;
using AlfaPeople.Models;

namespace AlfaPeople.Services
{
    public class WriteJSONService : IWriteJSONService
    {
        public WriteJSONService()
        {
        }
        /// <summary>
        /// Crea y guarda el archivo JSON con la lista de los pedidos
        /// </summary>
        /// <param name="route"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<string> write(
            Routes route, string payload)
        {
            string result = "";
            try
            {
                if (!Directory.Exists(route.Output))
                {
                    return "No existe la ruta " + route.Output +
                        ". Por favor ingrese una ruta válida para escribir el archivo JSON";
                }
                using (var stream = new FileStream(
                    Path.Combine(route.Output,
                    "pedidos.json"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var swriter = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        await swriter.WriteLineAsync(payload);
                    }
                }

                result = "El archivo JSON se creo correctamente";
            }
            catch (Exception ex)
            {
                result = this.GetType().Name + "-->" + ex.ToString();
            }

            return result;
        }
    }
}

