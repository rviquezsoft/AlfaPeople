using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlfaPeople.Models;
using Microsoft.Extensions.Configuration;

namespace AlfaPeople
{

    public class ReaderXML : IReaderXML
    {
        private readonly IExceptionsService logger;
        private readonly IConfiguration configuration;
        public ReaderXML(IExceptionsService _logger, IConfiguration _configuration)
        {
            logger = _logger;
            configuration = _configuration;
        }
        /// <summary>
        /// Se encarga de leer la ruta de entrada en el appsettings.json
        /// y devolver los directorios que contienen los archivos xml que van a
        /// ser procesados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Folders>> read(Routes routes, List<Folders> folders)
        {
            List<Folders> list = null;
            try
            {
                string input = routes.Input;
                //Si la ruta no existe
                if (!Directory.Exists(input))
                {
                    await logger.LogToLogger(this.GetType().Name,
                        new IOException("No se encontró la ruta " + routes.Input));
                    return list;
                }

                var filesRoot = Directory.GetFiles(input, "*.xml");

                string concat = "";
                foreach (var item in folders)
                {
                    concat += "- " + item.carpeta;
                }

                //Si hay archivos en el directorio raíz
                if (filesRoot.Length > 0)
                {

                    await logger.LogToLogger($"Se detectaron archivos" +
                        $" en el directorio raíz, estos archivos no serán " +
                        $"tomados en cuenta, únicamente los archivos .xml" +
                        $"de los directorios: '{concat}' se procesaran");
                }
                var directories = Directory.GetDirectories(input);
                //Si no hay carpetas en el directorio de entrada
                if (directories.Length < 1)
                {
                    await logger.LogToLogger($"No se detectaron los directorios " +
                        $"necesarios para el procesamiento. " +
                        $"Por favor verifique que en la ruta de entrada del " +
                        $"archivo appsettings.json" +
                        $" se encuentren las carpetas '{concat}' " +
                        $"respectivamete");
                    return list;
                }
                //Si el directorio de entrada tiene carpetas pero no las que se
                //necesitan 
                var verification = false;
                list = new List<Folders>();
                foreach (var item in folders)
                {
                    var dir = directories
                        .Where(x => x.Contains(item.carpeta));

                    var flag = dir.Any();
                    if (flag)
                    {
                        verification = true;
                        item.carpeta = dir.FirstOrDefault();
                        list.Add(item);
                    }
                }

                if (!verification)
                {
                    await logger.LogToLogger("No se detectaron los directorios " +
                        "necesarios para el procesamiento. " +
                        "Por favor verifique que en la ruta de entrada del " +
                        "archivo appsettings.json" +
                        " se encuentren las carpetas 'COMPRAS' y 'VENTAS' " +
                        "respectivamete");
                    return list;
                }
            }
            catch (Exception ex)
            {
                await logger.LogToLogger(this.GetType().Name, ex);
            }
            return list;
        }
    }
}

